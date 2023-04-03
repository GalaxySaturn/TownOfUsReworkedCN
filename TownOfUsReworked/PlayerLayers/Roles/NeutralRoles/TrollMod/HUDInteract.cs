using HarmonyLib;
using TownOfUsReworked.Classes;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.TrollMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HUDInteract
    {
        public static void Postfix()
        {
            if (Utils.NoButton(PlayerControl.LocalPlayer, RoleEnum.Troll))
                return;

            var role = Role.GetRole<Troll>(PlayerControl.LocalPlayer);

            if (role.InteractButton == null)
                role.InteractButton = CustomButtons.InstantiateButton();

            role.InteractButton.UpdateButton(role, "INTERACT", role.InteractTimer(), CustomGameOptions.InteractCooldown, AssetManager.Placeholder, AbilityTypes.Direct, "ActionSecondary");
        }
    }
}