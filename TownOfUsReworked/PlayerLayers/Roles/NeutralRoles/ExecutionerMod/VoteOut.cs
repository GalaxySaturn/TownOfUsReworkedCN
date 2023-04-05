using HarmonyLib;
using TownOfUsReworked.CustomOptions;
using Hazel;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.ExecutionerMod
{
    [HarmonyPatch(typeof(ExileController), nameof(ExileController.Begin))]
    public static class MeetingExiledEnd
    {
        public static void Postfix(ExileController __instance)
        {
            var exiled = __instance.exiled;

            if (exiled == null)
                return;

            var player = exiled.Object;

            foreach (var exe in Role.GetRoles<Executioner>(RoleEnum.Executioner))
            {
                if (exe.TargetPlayer == null || (!CustomGameOptions.ExeCanWinBeyondDeath && exe.Player.Data.IsDead))
                    continue;

                if (player == exe.TargetPlayer)
                {
                    exe.TargetVotedOut = true;
                    exe.SetDoomed(MeetingHud.Instance);
                    var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.WinLose, SendOption.Reliable);
                    writer.Write((byte)WinLoseRPC.ExecutionerWin);
                    writer.Write(exe.Player.PlayerId);
                    AmongUsClient.Instance.FinishRpcImmediately(writer);
                }
            }
        }
    }
}