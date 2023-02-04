using System;
using HarmonyLib;
using Hazel;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.PlayerLayers.Roles.Roles;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using TownOfUsReworked.Patches;

namespace TownOfUsReworked.PlayerLayers.Roles.CrewRoles.RevealerMod
{
    [HarmonyPatch(typeof(AirshipExileController), nameof(AirshipExileController.WrapUpAndSpawn))]
    public static class AirshipExileController_WrapUpAndSpawn
    {
        public static void Postfix(AirshipExileController __instance) => SetRevealer.ExileControllerPostfix(__instance);
    }
    
    [HarmonyPatch(typeof(ExileController), nameof(ExileController.WrapUp))]
    public class SetRevealer
    {
        public static PlayerControl WillBeRevealer;

        public static void ExileControllerPostfix(ExileController __instance)
        {
            var exiled = __instance.exiled?.Object;

            if (WillBeRevealer != null && !WillBeRevealer.Data.IsDead && exiled.Is(Faction.Crew))
                WillBeRevealer = exiled;
            
            if (!PlayerControl.LocalPlayer.Data.IsDead && exiled != PlayerControl.LocalPlayer)
                return;

            if (exiled == PlayerControl.LocalPlayer && PlayerControl.LocalPlayer.Is(RoleEnum.Jester))
                return;

            if (PlayerControl.LocalPlayer != WillBeRevealer)
                return;

            if (!PlayerControl.LocalPlayer.Is(RoleEnum.Revealer))
            {
                var former = Role.GetRole(PlayerControl.LocalPlayer);
                Role.RoleDictionary.Remove(PlayerControl.LocalPlayer.PlayerId);
                var role = new Revealer(PlayerControl.LocalPlayer);
                role.RegenTask();
                role.RoleHistory.AddRange(former.RoleHistory);
                role.FormerRole = former;

                RemoveTasks(PlayerControl.LocalPlayer);
                PlayerControl.LocalPlayer.MyPhysics.ResetMoveState();

                PlayerControl.LocalPlayer.gameObject.layer = LayerMask.NameToLayer("Players");

                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.RevealerDied, SendOption.Reliable, -1);
                writer.Write(PlayerControl.LocalPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
            }

            if (Role.GetRole<Revealer>(PlayerControl.LocalPlayer).Caught)
                return;

            var startingVent = ShipStatus.Instance.AllVents[Random.RandomRangeInt(0, ShipStatus.Instance.AllVents.Count)];

            var writer2 = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetPos, SendOption.Reliable, -1);
            writer2.Write(PlayerControl.LocalPlayer.PlayerId);
            writer2.Write(startingVent.transform.position.x);
            writer2.Write(startingVent.transform.position.y + 0.3636f);
            AmongUsClient.Instance.FinishRpcImmediately(writer2);

            PlayerControl.LocalPlayer.NetTransform.RpcSnapTo(new Vector2(startingVent.transform.position.x, startingVent.transform.position.y + 0.3636f));
            PlayerControl.LocalPlayer.MyPhysics.RpcEnterVent(startingVent.Id);
        }

        public static void Postfix(ExileController __instance) => ExileControllerPostfix(__instance);

        [HarmonyPatch(typeof(Object), nameof(Object.Destroy), new Type[] { typeof(GameObject) })]
        public static void Prefix(GameObject obj)
        {
            if (!SubmergedCompatibility.Loaded || GameOptionsManager.Instance.currentNormalGameOptions.MapId != 5)
                return;

            if (obj.name.Contains("ExileCutscene"))
                ExileControllerPostfix(ExileControllerPatch.lastExiled);
        }

        public static void RemoveTasks(PlayerControl player)
        {
            foreach (var task in player.myTasks)
            {
                if (task.TryCast<NormalPlayerTask>() != null)
                {
                    var normalPlayerTask = task.Cast<NormalPlayerTask>();

                    var updateArrow = normalPlayerTask.taskStep > 0;
                    
                    normalPlayerTask.taskStep = 0;
                    normalPlayerTask.Initialize();

                    if (normalPlayerTask.TaskType == TaskTypes.PickUpTowels)
                    {
                        foreach (var console in Object.FindObjectsOfType<TowelTaskConsole>())
                            console.Image.color = Color.white;
                    }

                    normalPlayerTask.taskStep = 0;

                    if (normalPlayerTask.TaskType == TaskTypes.UploadData)
                        normalPlayerTask.taskStep = 1;

                    if (updateArrow)
                        normalPlayerTask.UpdateArrow();
                    
                    var taskInfo = player.Data.FindTaskById(task.Id);
                    taskInfo.Complete = false;
                }
            }
        }
    }
}