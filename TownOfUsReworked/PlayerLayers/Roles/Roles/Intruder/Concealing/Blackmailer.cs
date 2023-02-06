using System;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Lobby.CustomOption;
using TownOfUsReworked.Patches;
using TownOfUsReworked.Classes;
using Il2CppSystem.Collections.Generic;
using Hazel;

namespace TownOfUsReworked.PlayerLayers.Roles.Roles
{
    public class Blackmailer : Role
    {
        private KillButton _blackmailButton;
        public PlayerControl ClosestPlayer = null;
        public PlayerControl Blackmailed = null;
        public DateTime LastBlackmailed;
        public bool blackmailed => Blackmailed != null;
        private KillButton _killButton;
        public DateTime LastKilled { get; set; }

        public Blackmailer(PlayerControl player) : base(player)
        {
            Name = "Blackmailer";
            StartText = "You Know Their Dirty Little Secrets";
            AbilitiesText = "- You can blackmail players to ensure they cannot speak in the next meeting.";
            AttributesText = "- You can blackmail fellow <color=#FF0000FF>Intruders</color>.\n- Everyone will be alerted at the start of the meeting" + 
                " that someone has been blackmailed.";
            Color = CustomGameOptions.CustomIntColors ? Colors.Blackmailer : Colors.Intruder;
            RoleType = RoleEnum.Blackmailer;
            Faction = Faction.Intruder;
            FactionName = "Intruder";
            FactionColor = Colors.Intruder;
            RoleAlignment = RoleAlignment.IntruderConceal;
            AlignmentName = "Intruder (Concealing)";
            Results = InspResults.SherConsigInspBm;
            AlignmentDescription = ICDescription;
            Objectives = IsRecruit ? JackalWinCon : IntrudersWinCon;
            FactionDescription = IntruderFactionDescription;
            RoleDescription = blackmailed ? "You are a Blackmailer! You can choose to silent the crew to ensure no information gets into the wrong hands. Be " +
                $"careful though, as you cannot blackmail yourself so the others will get wise to your identity pretty quickly. Currently {Blackmailed.name} is blackmailed." :
                "You are a Blackmailer! You can choose to silent the crew to ensure no information gets into the wrong hands. Be careful though, as you cannot" +
                " blackmail yourself so the others will get wise to your identity pretty quickly.";
        }

        public KillButton KillButton
        {
            get => _killButton;
            set
            {
                _killButton = value;
                AddToAbilityButtons(value, this);
            }
        }

        public KillButton BlackmailButton
        {
            get => _blackmailButton;
            set
            {
                _blackmailButton = value;
                AddToAbilityButtons(value, this);
            }
        }
        
        public float BlackmailTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastBlackmailed;
            var num = CustomGameOptions.BlackmailCd * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;

            if (flag2)
                return 0;

            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }

        protected override void IntroPrefix(IntroCutscene._ShowTeam_d__32 __instance)
        {
            if (Player != PlayerControl.LocalPlayer)
                return;
                
            var team = new List<PlayerControl>();

            team.Add(PlayerControl.LocalPlayer);

            if (!IsRecruit)
            {
                foreach (var player in PlayerControl.AllPlayerControls)
                {
                    if (player.Is(Faction) && player != PlayerControl.LocalPlayer)
                        team.Add(player);
                }
            }
            else
            {
                var jackal = Player.GetJackal();

                team.Add(jackal.Player);
                team.Add(jackal.GoodRecruit);
            }

            __instance.teamToShow = team;
        }

        public override void Wins()
        {
            if (IsRecruit)
                CabalWin = true;
            else
                IntruderWin = true;
        }

        public float KillTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastKilled;
            var num = CustomGameOptions.IntKillCooldown * 1000f;
            var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;

            if (flag2)
                return 0;

            return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
        }

        internal override bool GameEnd(LogicGameFlowNormal __instance)
        {
            if (Player.Data.IsDead || Player.Data.Disconnected)
                return true;

            if (IsRecruit)
            {
                if (Utils.CabalWin())
                {
                    Wins();
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.WinLose, SendOption.Reliable, -1);
                    writer.Write((byte)WinLoseRPC.CabalWin);
                    writer.Write(Player.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    Utils.EndGame();
                    return false;
                }
            }
            else if (Utils.IntrudersWin())
            {
                Wins();
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.WinLose, SendOption.Reliable, -1);
                writer.Write((byte)WinLoseRPC.IntruderWin);
                writer.Write(Player.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                Utils.EndGame();
                return false;
            }

            return false;
        }
    }
}