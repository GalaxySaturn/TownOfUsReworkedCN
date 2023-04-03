using HarmonyLib;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles.CrewRoles.RevealerMod
{
    [HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.HandleAnimation))]
    public static class HandleAnimation
    {
        public static void Prefix(PlayerPhysics __instance, [HarmonyArgument(0)] ref bool amDead)
        {
            if (__instance.myPlayer.Is(RoleEnum.Revealer))
                amDead = Role.GetRole<Revealer>(__instance.myPlayer).Caught;
        }
    }
}