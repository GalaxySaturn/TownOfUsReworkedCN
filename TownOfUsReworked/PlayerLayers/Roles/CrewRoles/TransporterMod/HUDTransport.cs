using HarmonyLib;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Classes;
using TownOfUsReworked.Lobby.CustomOption;
using UnityEngine;
using TownOfUsReworked.PlayerLayers.Roles.Roles;

namespace TownOfUsReworked.PlayerLayers.Roles.CrewRoles.TransporterMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HUDTransport
    {
        public static Sprite Transport => TownOfUsReworked.TransportSprite;

        public static void Postfix(HudManager __instance)
        {
            if (Utils.NoButton(PlayerControl.LocalPlayer, RoleEnum.Transporter))
                return;

            var role = Role.GetRole<Transporter>(PlayerControl.LocalPlayer);

            if (role.TransportButton == null)
            {
                role.TransportButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.TransportButton.graphic.enabled = true;
                role.TransportButton.graphic.sprite = Transport;
                role.TransportButton.gameObject.SetActive(false);
            }

            if (role.UsesText == null && role.UsesLeft > 0)
            {
                role.UsesText = Object.Instantiate(role.TransportButton.cooldownTimerText, role.TransportButton.transform);
                role.UsesText.transform.localPosition = new Vector3(role.UsesText.transform.localPosition.x + 0.26f, role.UsesText.transform.localPosition.y + 0.29f,
                    role.UsesText.transform.localPosition.z);
                role.UsesText.transform.localScale = role.UsesText.transform.localScale * 0.65f;
                role.UsesText.alignment = TMPro.TextAlignmentOptions.Right;
                role.UsesText.fontStyle = TMPro.FontStyles.Bold;
                role.UsesText.gameObject.SetActive(false);
            }

            if (role.UsesText != null)
                role.UsesText.text = $"{role.UsesLeft}";

            role.TransportButton.gameObject.SetActive(Utils.SetActive(role.Player, __instance) && role.ButtonUsable);
            role.UsesText.gameObject.SetActive(Utils.SetActive(role.Player, __instance) && role.ButtonUsable);

            if (role.ButtonUsable)
                role.TransportButton.SetCoolDown(role.TransportTimer(), CustomGameOptions.TransportCooldown);

            var renderer = role.TransportButton.graphic;
            
            if (!role.TransportButton.isCoolingDown && role.ButtonUsable)
            {
                renderer.color = Palette.EnabledColor;
                renderer.material.SetFloat("_Desat", 0f);
                role.UsesText.color = Palette.EnabledColor;
                role.UsesText.material.SetFloat("_Desat", 0f);
            }
            else
            {
                renderer.color = Palette.DisabledClear;
                renderer.material.SetFloat("_Desat", 1f);
                role.UsesText.color = Palette.DisabledClear;
                role.UsesText.material.SetFloat("_Desat", 1f);
            }
        }
    }
}