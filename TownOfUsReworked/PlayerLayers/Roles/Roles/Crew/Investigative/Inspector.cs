using TownOfUsReworked.Enums;
using TownOfUsReworked.Patches;
using TownOfUsReworked.Lobby.CustomOption;
using Il2CppSystem.Collections.Generic;
using System;
using TownOfUsReworked.Classes;
using Hazel;

namespace TownOfUsReworked.PlayerLayers.Roles.Roles
{
    public class Inspector : Role
    {
        public PlayerControl ClosestPlayer;
        public DateTime LastInspected { get; set; }
        public List<PlayerControl> Inspected = new List<PlayerControl>();
        private KillButton _inspectButton;

        public Inspector(PlayerControl player) : base(player)
        {
            Name = "Inspector";
            Faction = Faction.Crew;
            RoleType = RoleEnum.Inspector;
            StartText = "Inspect Player For Their Roles";
            AbilitiesText = "- You can check a player to get a role list of what they could be.";
            Color = CustomGameOptions.CustomCrewColors ? Colors.Inspector : Colors.Crew;
            FactionName = "Crew";
            FactionColor = Colors.Crew;
            RoleAlignment = RoleAlignment.CrewInvest;
            AlignmentName = "Crew (Investigative)";
            Results = InspResults.SherConsigInspBm;
            FactionDescription = CrewFactionDescription;
            AlignmentDescription = CIDescription;
            RoleDescription = "You are an Inspector! You can inspect players to see a role list of what they could be. If someone's claim is not in that " +
                "list, they are not Crew.";
            Objectives = CrewWinCon;
            LastInspected = DateTime.UtcNow;
        }

        public KillButton InspectButton
        {
            get => _inspectButton;
            set
            {
                _inspectButton = value;
                AddToAbilityButtons(value, this);
            }
        }

        protected override void IntroPrefix(IntroCutscene._ShowTeam_d__32 __instance)
        {
            if (Player != PlayerControl.LocalPlayer)
                return;
                
            var team = new List<PlayerControl>();

            team.Add(PlayerControl.LocalPlayer);

            if (IsRecruit)
            {
                var jackal = Player.GetJackal();

                team.Add(jackal.Player);
                team.Add(jackal.EvilRecruit);
            }

            __instance.teamToShow = team;
        }

        public float InspectTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastInspected;
            var num = CustomGameOptions.InspectCooldown * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;

            if (flag2)
                return 0;
                
            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public override void Wins()
        {
            if (IsRecruit)
                CabalWin = true;
            else if (IsIntTraitor)
                IntruderWin = true;
            else if (IsSynTraitor)
                SyndicateWin = true;
            else
                CrewWin = true;
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
            else if (IsIntTraitor || IsIntFanatic)
            {
                if (Utils.IntrudersWin())
                {
                    Wins();
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.WinLose, SendOption.Reliable, -1);
                    writer.Write((byte)WinLoseRPC.IntruderWin);
                    writer.Write(Player.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    Utils.EndGame();
                    return false;
                }
            }
            else if (IsSynTraitor || IsSynFanatic)
            {
                if (Utils.SyndicateWins())
                {
                    Wins();
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.WinLose, SendOption.Reliable, -1);
                    writer.Write((byte)WinLoseRPC.SyndicateWin);
                    writer.Write(Player.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                    Utils.EndGame();
                    return false;
                }
            }
            else if (Utils.CrewWins())
            {
                Wins();
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.WinLose, SendOption.Reliable, -1);
                writer.Write((byte)WinLoseRPC.CrewWin);
                writer.Write(Player.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                Utils.EndGame();
                return false;
            }

            return false;
        }
    }
}