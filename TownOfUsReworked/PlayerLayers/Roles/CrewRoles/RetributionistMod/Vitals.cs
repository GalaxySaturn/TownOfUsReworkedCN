using System;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Classes;
using TownOfUsReworked.Patches;
using TownOfUsReworked.PlayerLayers.Roles.Roles;

namespace TownOfUsReworked.PlayerLayers.Roles.CrewRoles.RetributionistMod
{
    [HarmonyPatch(typeof(VitalsMinigame), nameof(VitalsMinigame.Update))]
    public class Vitals
    {
        public static void Postfix(VitalsMinigame __instance)
        {
            var localPlayer = PlayerControl.LocalPlayer;

            if (!localPlayer.Is(RoleEnum.Retributionist))
                return;
            
            var retRole = Role.GetRole<Retributionist>(localPlayer);

            if (retRole.RevivedRole.RoleType == RoleEnum.Agent)
            {
                for (var i = 0; i < __instance.vitals.Count; i++)
                {
                    var panel = __instance.vitals[i];
                    var info = GameData.Instance.AllPlayers.ToArray()[i];

                    if (!panel.IsDead)
                        continue;

                    var deadBody = Murder.KilledPlayers.First(x => x.PlayerId == info.PlayerId);
                    var num = (float) (DateTime.UtcNow - deadBody.KillTime).TotalMilliseconds;
                    var cardio = panel.Cardio.gameObject;
                    var tmp = cardio.GetComponent<TMPro.TextMeshPro>();

                    if (tmp == null)
                        tmp = cardio.AddComponent<TMPro.TextMeshPro>();

                    var transform = tmp.transform;
                    transform.localPosition = new Vector3(-0.85f, -0.4f, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.localScale = Vector3.one / 20;
                    tmp.color = Color.red;
                    tmp.text = Math.Ceiling(num / 1000) + "s";
                }
            }
        }
    }
    
    [HarmonyPatch(typeof(VitalsMinigame), nameof(VitalsMinigame.Begin))]
    public class NoVitals
    {
        public static bool Prefix(VitalsMinigame __instance)
        {
            if (PlayerControl.LocalPlayer.Is(RoleEnum.Retributionist) && !PlayerControl.LocalPlayer.Data.IsDead && VitalsMinigame.Instance)
            {
                var retRole = Role.GetRole<Retributionist>(PlayerControl.LocalPlayer);

                if (retRole.RevivedRole.RoleType != RoleEnum.TimeLord)
                    return true;

                __instance.Close();
            }

            return true;
        }
    }
}