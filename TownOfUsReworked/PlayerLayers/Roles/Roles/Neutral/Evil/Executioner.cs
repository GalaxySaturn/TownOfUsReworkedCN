using Il2CppSystem.Collections.Generic;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Lobby.CustomOption;
using TownOfUsReworked.Classes;
using TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.NeutralsMod;

namespace TownOfUsReworked.PlayerLayers.Roles.Roles
{
    public class Executioner : Role
    {
        public PlayerControl TargetPlayer = null;
        public bool TargetVotedOut;

        public Executioner(PlayerControl player) : base(player)
        {
            Name = "Executioner";
            StartText = "Eject Your Target";
            Objectives = "- Eject your target.";
            Color = CustomGameOptions.CustomNeutColors ? Colors.Executioner : Colors.Neutral;
            RoleType = RoleEnum.Executioner;
            Faction = Faction.Neutral;
            FactionName = "Neutral";
            FactionColor = Colors.Neutral;
            RoleAlignment = RoleAlignment.NeutralEvil;
            AlignmentName = "Neutral (Evil)";
            RoleDescription = "You are an Executioner! You are a crazed stalker who only wants to see your target get ejected. Eject them at all costs!";
        }

        public override void Loses()
        {
            LostByRPC = true;
        }

        protected override void IntroPrefix(IntroCutscene._ShowTeam_d__32 __instance)
        {
            if (Player != PlayerControl.LocalPlayer)
                return;
                
            var team = new List<PlayerControl>();
            team.Add(PlayerControl.LocalPlayer);
            team.Add(TargetPlayer);
            __instance.teamToShow = team;
        }

        public override void Wins()
        {
            if ((Player.Data.IsDead && !CustomGameOptions.ExeCanWinBeyondDeath) || Player.Data.Disconnected || TargetPlayer == null)
                return;

            if (IsRecruit)
                CabalWin = true;
            else if (IsIntAlly)
                IntruderWin = true;
            else if (IsSynAlly)
                SyndicateWin = true;
            else if (IsCrewAlly)
                CrewWin = true;
            else if (IsPersuaded)
                SectWin = true;
            else if (IsResurrected)
                ReanimatedWin = true;
            else if (CustomGameOptions.NoSolo == NoSolo.AllNeutrals)
                AllNeutralsWin = true;
        }
    }
}