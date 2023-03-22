using System;
using HarmonyLib;
using TownOfUsReworked.Enums;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Classes;

namespace TownOfUsReworked.PlayerLayers.Roles.SyndicateRoles.SyndicateMod
{
    [HarmonyPatch(typeof(AbilityButton), nameof(AbilityButton.DoClick))]
    public class PerformKill
    {
        public static bool Prefix(AbilityButton __instance)
        {
            if (Utils.NoButton(PlayerControl.LocalPlayer, Faction.Syndicate))
                return true;

            if (PlayerControl.LocalPlayer.Is(ObjectifierEnum.Allied) || PlayerControl.LocalPlayer.Is(ObjectifierEnum.Traitor) || PlayerControl.LocalPlayer.Is(ObjectifierEnum.Fanatic))
                return false;

            if (PlayerControl.LocalPlayer.Is(RoleEnum.Banshee))
                return false;

            var role = Role.GetRole<SyndicateRole>(PlayerControl.LocalPlayer);

            if (__instance == role.KillButton)
            {
                if (!Utils.ButtonUsable(role.KillButton))
                    return false;

                if (Utils.IsTooFar(role.Player, role.ClosestPlayer))
                    return false;

                if (role.KillTimer() != 0f)
                    return false;

                var interact = Utils.Interact(role.Player, role.ClosestPlayer, true);

                if (interact[3] == true || interact[0] == true)
                    role.LastKilled = DateTime.UtcNow;
                else if (interact[1] == true)
                    role.LastKilled.AddSeconds(CustomGameOptions.ProtectKCReset);
                else if (interact[2] == true)
                    role.LastKilled.AddSeconds(CustomGameOptions.VestKCReset);

                return false;
            }

            return true;
        }
    }
}