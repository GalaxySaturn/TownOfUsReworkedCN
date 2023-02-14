﻿using HarmonyLib;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Classes;
using TownOfUsReworked.PlayerLayers.Roles.Roles;
using UnityEngine;

namespace TownOfUsReworked.PlayerLayers.Roles.CrewRoles.MedicMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class HUDProtect
    {
        public static Sprite Medic => TownOfUsReworked.MedicSprite;

        public static void Postfix(HudManager __instance)
        {
            if (Utils.NoButton(PlayerControl.LocalPlayer, RoleEnum.Medic))
                return;

            var role = Role.GetRole<Medic>(PlayerControl.LocalPlayer);

            if (role.ShieldButton == null)
            {
                role.ShieldButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.ShieldButton.graphic.enabled = true;
                role.ShieldButton.graphic.sprite = Medic;
                role.ShieldButton.gameObject.SetActive(false);
            }

            role.ShieldButton.gameObject.SetActive(Utils.SetActive(role.Player, __instance) && !role.UsedAbility);
            role.ShieldButton.SetCoolDown(0f, 1f);
            Utils.SetTarget(ref role.ClosestPlayer, role.ShieldButton);
            var renderer = role.ShieldButton.graphic;
            
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