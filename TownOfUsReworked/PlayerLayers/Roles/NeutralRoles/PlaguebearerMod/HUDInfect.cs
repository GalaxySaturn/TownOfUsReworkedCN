using System.Linq;
using HarmonyLib;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Lobby.CustomOption;
using TownOfUsReworked.Classes;
using UnityEngine;
using Hazel;
using TownOfUsReworked.PlayerLayers.Roles.Roles;

namespace TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.PlaguebearerMod
{
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HUDInfect
    {
        public static Sprite Infect => TownOfUsReworked.InfectSprite;

        public static void Postfix(HudManager __instance)
        {
            if (Utils.NoButton(PlayerControl.LocalPlayer, RoleEnum.Plaguebearer))
                return;

            var role = Role.GetRole<Plaguebearer>(PlayerControl.LocalPlayer);
            var isDead = role.Player.Data.IsDead;

            foreach (var playerId in role.InfectedPlayers)
            {
                var player = Utils.PlayerById(playerId);
                var data = player?.Data;

                if (data == null || data.Disconnected || data.IsDead || isDead || playerId == role.Player.PlayerId)
                    continue;

                player.myRend().material.SetColor("_VisorColor", role.Color);
                player.nameText().color = Color.black;
            }

            if (role.InfectButton == null)
            {
                role.InfectButton = Object.Instantiate(__instance.KillButton, __instance.KillButton.transform.parent);
                role.InfectButton.graphic.enabled = true;
                role.InfectButton.graphic.sprite = Infect;
                role.InfectButton.gameObject.SetActive(false);
            }

            role.InfectButton.gameObject.SetActive(Utils.SetActive(role.Player, __instance) && !role.CanTransform);
            role.InfectButton.SetCoolDown(role.InfectTimer(), CustomGameOptions.InfectCd);
            var notInfected = PlayerControl.AllPlayerControls.ToArray().Where(player => !role.InfectedPlayers.Contains(player.PlayerId)).ToList();
            Utils.SetTarget(ref role.ClosestPlayer, role.InfectButton, notInfected);
            var renderer = role.InfectButton.graphic;
            
            if (role.ClosestPlayer != null && !role.InfectButton.isCoolingDown)
            {
                renderer.color = Palette.EnabledColor;
                renderer.material.SetFloat("_Desat", 0f);
            }
            else
            {
                renderer.color = Palette.DisabledClear;
                renderer.material.SetFloat("_Desat", 1f);
            }

            if (role.CanTransform && PlayerControl.AllPlayerControls.ToArray().Where(x => !x.Data.IsDead && !x.Data.Disconnected).ToList().Count > 1 && !isDead)
            {
                var transform = CustomGameOptions.PestSpawn || role.CanTransform;
                
                if (transform)
                {
                    role.TurnPestilence();
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Change, SendOption.Reliable, -1);
                    writer.Write((byte)TurnRPC.TurnPestilence);
                    writer.Write(PlayerControl.LocalPlayer.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                }
            }
        }
    }
}