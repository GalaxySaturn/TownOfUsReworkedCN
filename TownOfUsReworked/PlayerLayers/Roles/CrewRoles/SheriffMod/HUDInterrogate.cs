﻿using System.Linq;
using HarmonyLib;
using TownOfUsReworked.Classes;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles.CrewRoles.SheriffMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HUDInterrogate
    {
        public static void Postfix()
        {
            if (Utils.NoButton(PlayerControl.LocalPlayer, RoleEnum.Sheriff))
                return;

            var role = Role.GetRole<Sheriff>(PlayerControl.LocalPlayer);

            if (role.InterrogateButton == null)
                role.InterrogateButton = CustomButtons.InstantiateButton();

            var notInvestigated = PlayerControl.AllPlayerControls.ToArray().Where(x => !role.Interrogated.Contains(x.PlayerId)).ToList();
            role.InterrogateButton.UpdateButton(role, "INTERROGATE", role.InterrogateTimer(), CustomGameOptions.InterrogateCd, AssetManager.Interrogate, AbilityTypes.Direct,
                "ActionSecondary", notInvestigated);
        }
    }
}