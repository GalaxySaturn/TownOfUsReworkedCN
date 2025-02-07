namespace TownOfUsReworked.MultiClientInstancing
{
    [HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.CoStartGameHost))]
    public sealed class OnGameStart
    {
        public static void Prefix(AmongUsClient __instance)
        {
            if (TownOfUsReworked.MCIActive)
                __instance.allClients.ForEach(x => x.IsReady = true);
        }
    }

    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Confirm))]
    [HarmonyPriority(Priority.Last)]
    public sealed class SameVoteAll
    {
        public static void Postfix(MeetingHud __instance, ref byte suspectStateIdx)
        {
            if (!ConstantVariables.IsLocalGame || !TownOfUsReworked.MCIActive || !TownOfUsReworked.SameVote)
                return;

            var sus = suspectStateIdx;
            CustomPlayer.AllPlayers.ForEach(x => __instance.CmdCastVote(x.PlayerId, sus));
        }
    }
}