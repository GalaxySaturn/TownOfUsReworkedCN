using HarmonyLib;
using Hazel;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.PlayerLayers.Roles.Roles;
using TownOfUsReworked.Patches;
using TownOfUsReworked.Lobby.CustomOption;
using UnityEngine;

namespace TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.GuardianAngelMod
{
    public enum BecomeOptions
    {
        Crew,
        Amnesiac,
        Survivor,
        Jester
    }

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public class GATargetColor
    {
        private static void UpdateMeeting(MeetingHud __instance, GuardianAngel role)
        {
            if (CustomGameOptions.GAKnowsTargetRole)
                return;

            foreach (var player in __instance.playerStates)
            {
                if (player.TargetPlayerId == role.TargetPlayer.PlayerId)
                {
                    player.NameText.color = new Color32(255, 217, 0, 255);
                    player.NameText.text += "<color=#FFFFFFFF> ★</color>";
                }
            }
        }

        private static void Postfix(HudManager __instance)
        {
            if (PlayerControl.AllPlayerControls.Count <= 1)
                return;

            if (PlayerControl.LocalPlayer == null)
                return;

            if (PlayerControl.LocalPlayer.Data == null)
                return;

            if (!PlayerControl.LocalPlayer.Is(RoleEnum.GuardianAngel))
                return;

            if (PlayerControl.LocalPlayer.Data.IsDead)
                return;

            var role = Role.GetRole<GuardianAngel>(PlayerControl.LocalPlayer);

            if (MeetingHud.Instance != null)
                UpdateMeeting(MeetingHud.Instance, role);

            if (!CustomGameOptions.GAKnowsTargetRole)
            {
                role.TargetPlayer.nameText().color =  new Color32(255, 217, 0, 255);
                role.TargetPlayer.nameText().text += "<color=#FFFFFFFF> ★</color>";
            }

            if (role.TargetPlayer == null)
                return;

            if (!role.TargetPlayer.Data.IsDead && !role.TargetPlayer.Data.Disconnected)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.GAToSurv,
                SendOption.Reliable, -1);
            writer.Write(PlayerControl.LocalPlayer.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);

            Object.Destroy(role.UsesText);
            DestroyableSingleton<HudManager>.Instance.KillButton.gameObject.SetActive(false);

            GAToSurv(PlayerControl.LocalPlayer);
        }

        public static void GAToSurv(PlayerControl player)
        {
            var ga = Role.GetRole<GuardianAngel>(player);
            Role newRole;

            if (CustomGameOptions.GaOnTargetDeath == BecomeOptions.Jester)
                newRole = new Jester(player);
            else if (CustomGameOptions.GaOnTargetDeath == BecomeOptions.Amnesiac)
                newRole = new Amnesiac(player);
            else if (CustomGameOptions.GaOnTargetDeath == BecomeOptions.Survivor)
                newRole = new Survivor(player);
            else
                newRole = new Crewmate(player);

            newRole.RoleHistory.Add(ga);
            newRole.RoleHistory.AddRange(ga.RoleHistory);
            
            if (newRole.Player == PlayerControl.LocalPlayer)
                newRole.RegenTask();
        }
    }
}