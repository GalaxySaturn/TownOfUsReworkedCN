using HarmonyLib;
using TownOfUsReworked.Classes;
using TownOfUsReworked.CustomOptions;
using UnityEngine;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles.CrewRoles.MediumMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HUDMediate
    {
        public static void Postfix()
        {
            if (Utils.NoButton(PlayerControl.LocalPlayer, RoleEnum.Medium))
                return;

            var role = Role.GetRole<Medium>(PlayerControl.LocalPlayer);

            if (role.MediateButton == null)
                role.MediateButton = CustomButtons.InstantiateButton();

            role.MediateButton.UpdateButton(role, "MEDIATE", role.MediateTimer(), CustomGameOptions.MediateCooldown, AssetManager.Mediate, AbilityTypes.Effect, "ActionSecondary");

            if (!PlayerControl.LocalPlayer.Data.IsDead)
            {
                foreach (var player in PlayerControl.AllPlayerControls)
                {
                    if (role.MediatedPlayers.ContainsKey(player.PlayerId))
                    {
                        role.MediatedPlayers.GetValueSafe(player.PlayerId).target = player.transform.position;
                        player.Visible = true;

                        if (!CustomGameOptions.ShowMediatePlayer)
                        {
                            player.SetOutfit(CustomPlayerOutfitType.Camouflage, new GameData.PlayerOutfit()
                            {
                                ColorId = player.GetDefaultOutfit().ColorId,
                                HatId = "",
                                SkinId = "",
                                VisorId = "",
                                PlayerName = " "
                            });

                            PlayerMaterial.SetColors(Color.grey, player.MyRend());
                        }
                    }
                }
            }
        }
    }
}