﻿using HarmonyLib;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Lobby.CustomOption;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.PlayerLayers.Roles.Roles;
using System.Linq;
using UnityEngine;

namespace TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.DraculaMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HUDConvert
    {
        public static Sprite ConvertSprite => TownOfUsReworked.Placeholder;

        public static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1)
                return;

            if (PlayerControl.LocalPlayer == null)
                return;

            if (PlayerControl.LocalPlayer.Data == null)
                return;

            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Dracula))
                return;

            var data = PlayerControl.LocalPlayer.Data;
            var isDead = data.IsDead;
            var role = Role.GetRole<Dracula>(PlayerControl.LocalPlayer);

            if (role.BiteButton == null)
            {
                role.BiteButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.BiteButton.graphic.enabled = true;
                role.BiteButton.gameObject.SetActive(false);
            }

            role.BiteButton.gameObject.SetActive(!MeetingHud.Instance && !isDead && !LobbyBehaviour.Instance);
            role.BiteButton.SetCoolDown(role.ConvertTimer(), CustomGameOptions.BiteCd);
            var notVamp = PlayerControl.AllPlayerControls.ToArray().Where(player => !role.Converted.Contains(player)).ToList();
            Utils.SetTarget(ref role.ClosestPlayer, role.BiteButton, float.NaN, notVamp);
            var renderer = role.BiteButton.graphic;
            
            if (role.ClosestPlayer != null)
            {
                renderer.color = Palette.EnabledColor;
                renderer.material.SetFloat("_Desat", 0f);
            }
            else
            {
                renderer.color = Palette.DisabledClear;
                renderer.material.SetFloat("_Desat", 1f);
            }
        }
    }
}
