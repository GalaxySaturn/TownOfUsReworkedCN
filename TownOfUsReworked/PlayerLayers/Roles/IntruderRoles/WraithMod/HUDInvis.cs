using HarmonyLib;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Classes;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles.IntruderRoles.WraithMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HUDInvis
    {
        public static void Postfix()
        {
            if (Utils.NoButton(PlayerControl.LocalPlayer, RoleEnum.Wraith))
                return;

            var role = Role.GetRole<Wraith>(PlayerControl.LocalPlayer);

            if (role.InvisButton == null)
                role.InvisButton = CustomButtons.InstantiateButton();

            role.InvisButton.UpdateButton(role, "INVIS", role.InvisTimer(), CustomGameOptions.InvisCd, AssetManager.Invis, AbilityTypes.Effect, "Secondary", null, true, !role.IsInvis,
                role.IsInvis, role.TimeRemaining, CustomGameOptions.InvisDuration);
        }
    }
}