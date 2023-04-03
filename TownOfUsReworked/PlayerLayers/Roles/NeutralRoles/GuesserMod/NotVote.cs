using HarmonyLib;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.GuesserMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.VotingComplete))]
    public static class VotingComplete
    {
        public static void Postfix()
        {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Guesser))
            {
                var assassin = Role.GetRole<Guesser>(PlayerControl.LocalPlayer);
                ShowHideGuessButtons.HideButtons(assassin);
            }
        }
    }
}