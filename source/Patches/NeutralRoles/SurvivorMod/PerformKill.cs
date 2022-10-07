using HarmonyLib;
using Hazel;
using TownOfUs.Roles;
using UnityEngine;

namespace TownOfUs.NeutralRoles.SurvivorMod
{
    [HarmonyPatch(typeof(KillButton), nameof(KillButton.DoClick))]
    public class Vest
    {
        public static bool Prefix(KillButton __instance)
        {
            var flag = PlayerControl.LocalPlayer.Is(RoleEnum.Survivor);
            if (!flag) return true;
            if (!PlayerControl.LocalPlayer.CanMove) return false;
            if (PlayerControl.LocalPlayer.Data.IsDead) return false;
            var role = Role.GetRole<Survivor>(PlayerControl.LocalPlayer);
            if (!role.ButtonUsable) return false;
            var vestButton = DestroyableSingleton<HudManager>.Instance.KillButton;
            if (__instance == vestButton)
            {
                if (__instance.isCoolingDown) return false;
                if (!__instance.isActiveAndEnabled) return false;
                if (role.VestTimer() != 0) return false;
                role.TimeRemaining = CustomGameOptions.VestDuration;
                role.UsesLeft--;
                role.Vest();
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId,
                    (byte)CustomRPC.Vest, SendOption.Reliable, -1);
                writer.Write(PlayerControl.LocalPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                try {
                    AudioClip AlertSFX = TownOfUs.loadAudioClipFromResources("TownOfUs.Resources.Survivor.raw");
                    SoundManager.Instance.PlaySound(AlertSFX, false, 0.4f);
                } catch {
                }
                return false;
            }

            return true;
        }
    }
}