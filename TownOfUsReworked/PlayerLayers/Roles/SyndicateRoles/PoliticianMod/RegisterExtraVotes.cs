using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Hazel;
using InnerNet;
using TownOfUsReworked.Classes;
using TownOfUsReworked.PlayerLayers.Abilities;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;
using Object = UnityEngine.Object;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles.SyndicateRoles.PoliticianMod
{
    [HarmonyPatch(typeof(MeetingHud))]
    public static class RegisterExtraVotes
    {
        [HarmonyPatch(nameof(MeetingHud.Update))]
        public static void Postfix(MeetingHud __instance)
        {
            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Politician))
                return;

            if (PlayerControl.LocalPlayer.Data.IsDead)
                return;

            if (__instance.TimerText.text.Contains("Can Vote"))
                return;

            var role = Role.GetRole<Politician>(PlayerControl.LocalPlayer);
            __instance.TimerText.text = $"Can Vote: {role.VoteBank} time(s) | {__instance.TimerText.text}";
        }

        public static Dictionary<byte, int> CalculateAllVotes(MeetingHud __instance)
        {
            var dictionary = new Dictionary<byte, int>();

            for (var i = 0; i < __instance.playerStates.Length; i++)
            {
                var playerVoteArea = __instance.playerStates[i];

                if (!playerVoteArea.DidVote || playerVoteArea.AmDead || playerVoteArea.VotedFor == PlayerVoteArea.MissedVote || playerVoteArea.VotedFor == PlayerVoteArea.DeadVote)
                    continue;

                if (dictionary.TryGetValue(playerVoteArea.VotedFor, out var num))
                    dictionary[playerVoteArea.VotedFor] = num + 1;
                else
                    dictionary[playerVoteArea.VotedFor] = 1;
            }

            foreach (var role in Role.GetRoles<Politician>(RoleEnum.Politician))
            {
                foreach (var number in role.ExtraVotes)
                {
                    if (dictionary.TryGetValue(number, out var num))
                        dictionary[number] = num + 1;
                    else
                        dictionary[number] = 1;
                }
            }

            dictionary.MaxPair(out var tie);

            if (tie)
            {
                foreach (var player in __instance.playerStates)
                {
                    if (!player.DidVote || player.AmDead || player.VotedFor == PlayerVoteArea.MissedVote || player.VotedFor == PlayerVoteArea.DeadVote)
                        continue;

                    var ability = Ability.GetAbility(player);

                    if (ability == null)
                        continue;

                    if (ability.AbilityType == AbilityEnum.Tiebreaker)
                    {
                        if (dictionary.TryGetValue(player.VotedFor, out var num))
                            dictionary[player.VotedFor] = num + 1;
                        else
                            dictionary[player.VotedFor] = 1;
                    }
                }
            }

            return dictionary;
        }

        [HarmonyPatch(nameof(MeetingHud.Start))]
        public static void Prefix()
        {
            foreach (var role in Role.GetRoles<Politician>(RoleEnum.Politician))
            {
                role.ExtraVotes.Clear();

                if (role.VoteBank < 0)
                    role.VoteBank = 0;

                role.VotedOnce = false;

                if (Role.SyndicateHasChaosDrive)
                    role.VoteBank += CustomGameOptions.ChaosDriveVoteAdd;
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(MeetingHud.HandleDisconnect), typeof(PlayerControl), typeof(DisconnectReasons))]
        public static void Prefix([HarmonyArgument(0)] PlayerControl player)
        {
            if (AmongUsClient.Instance.AmHost && MeetingHud.Instance)
            {
                foreach (var politician in Role.GetRoles<Politician>(RoleEnum.Politician))
                {
                    var votesRegained = politician.ExtraVotes.RemoveAll(x => x == player.PlayerId);

                    if (politician.Player == PlayerControl.LocalPlayer)
                        politician.VoteBank += votesRegained;

                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.AddPoliticianVoteBank, SendOption.Reliable);
                    writer.Write(politician.Player.PlayerId);
                    writer.Write(votesRegained);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                }
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Confirm))]
        public static class Confirm
        {
            public static bool Prefix(MeetingHud __instance)
            {
                if (!PlayerControl.LocalPlayer.Is(RoleEnum.Politician))
                    return true;

                if (__instance.state != MeetingHud.VoteStates.Voted)
                    return true;

                __instance.state = MeetingHud.VoteStates.NotVoted;
                return true;
            }

            [HarmonyPriority(Priority.First)]
            public static void Postfix(MeetingHud __instance)
            {
                if (!PlayerControl.LocalPlayer.Is(RoleEnum.Politician))
                    return;

                var role = Role.GetRole<Politician>(PlayerControl.LocalPlayer);

                if (role.CanVote)
                    __instance.SkipVoteButton.gameObject.SetActive(true);
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.CastVote))]
        public static class CastVote
        {
            public static bool Prefix(MeetingHud __instance, [HarmonyArgument(0)] byte srcPlayerId, [HarmonyArgument(1)] byte suspectPlayerId)
            {
                var player = PlayerControl.AllPlayerControls.ToArray().FirstOrDefault(x => x.PlayerId == srcPlayerId);

                if (!player.Is(RoleEnum.Politician))
                    return true;

                var playerVoteArea = __instance.playerStates.ToArray().First(pv => pv.TargetPlayerId == srcPlayerId);

                if (playerVoteArea.AmDead)
                    return false;

                var role = Role.GetRole<Politician>(player);

                if (playerVoteArea.DidVote)
                    role.ExtraVotes.Add(suspectPlayerId);
                else
                {
                    playerVoteArea.SetVote(suspectPlayerId);
                    playerVoteArea.Flag.enabled = true;
                    PlayerControl.LocalPlayer.RpcSendChatNote(srcPlayerId, ChatNoteTypes.DidVote);
                }

                __instance.Cast<InnerNetObject>().SetDirtyBit(1U);
                __instance.CheckForEndVoting();
                return false;
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.VotingComplete))]
        public static class VotingComplete
        {
            public static void Postfix([HarmonyArgument(1)] GameData.PlayerInfo exiled, [HarmonyArgument(2)] bool tie)
            {
                var exiledString = exiled == null ? "null" : exiled.PlayerName;
                Utils.LogSomething($"Exiled PlayerName = {exiledString}");
                Utils.LogSomething($"Was a tie = {tie}");
            }
        }

        [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.PopulateResults))]
        public static class PopulateResults
        {
            public static bool Prefix(MeetingHud __instance, [HarmonyArgument(0)] Il2CppStructArray<MeetingHud.VoterState> states)
            {
                var allNums = new Dictionary<int, int>();

                __instance.TitleText.text = Object.FindObjectOfType<TranslationController>() .GetString(StringNames.MeetingVotingResults, Array.Empty<Il2CppSystem.Object>());
                var amountOfSkippedVoters = 0;

                for (var i = 0; i < __instance.playerStates.Length; i++)
                {
                    var playerVoteArea = __instance.playerStates[i];
                    playerVoteArea.ClearForResults();
                    allNums.Add(i, 0);

                    for (var stateIdx = 0; stateIdx < states.Length; stateIdx++)
                    {
                        var voteState = states[stateIdx];
                        var playerInfo = GameData.Instance.GetPlayerById(voteState.VoterId);

                        if (playerInfo == null)
                            Debug.LogError(string.Format("Couldn't find player info for voter: {0}", voteState.VoterId));
                        else if (i == 0 && voteState.SkippedVote)
                        {
                            __instance.BloopAVoteIcon(playerInfo, amountOfSkippedVoters, __instance.SkippedVoting.transform);
                            amountOfSkippedVoters++;
                        }
                        else if (voteState.VotedForId == playerVoteArea.TargetPlayerId)
                        {
                            __instance.BloopAVoteIcon(playerInfo, allNums[i], playerVoteArea.transform);
                            allNums[i]++;
                        }
                    }
                }

                foreach (var politician in Role.GetRoles<Politician>(RoleEnum.Politician))
                {
                    var playerInfo = politician.Player.Data;
                    var anonVotesOption = CustomGameOptions.AnonymousVoting;
                    GameOptionsManager.Instance.currentNormalGameOptions.AnonymousVotes = CustomGameOptions.PoliticianAnonymous;

                    foreach (var extraVote in politician.ExtraVotes)
                    {
                        if (extraVote == PlayerVoteArea.HasNotVoted || extraVote == PlayerVoteArea.MissedVote || extraVote == PlayerVoteArea.DeadVote)
                            continue;

                        if (extraVote == PlayerVoteArea.SkippedVote)
                        {
                            __instance.BloopAVoteIcon(playerInfo, amountOfSkippedVoters, __instance.SkippedVoting.transform);
                            amountOfSkippedVoters++;
                        }
                        else
                        {
                            for (var i = 0; i < __instance.playerStates.Length; i++)
                            {
                                var area = __instance.playerStates[i];

                                if (extraVote != area.TargetPlayerId)
                                    continue;

                                __instance.BloopAVoteIcon(playerInfo, allNums[i], area.transform);
                                allNums[i]++;
                            }
                        }
                    }

                    GameOptionsManager.Instance.currentNormalGameOptions.AnonymousVotes = anonVotesOption;
                }

                return false;
            }
        }
    }
}