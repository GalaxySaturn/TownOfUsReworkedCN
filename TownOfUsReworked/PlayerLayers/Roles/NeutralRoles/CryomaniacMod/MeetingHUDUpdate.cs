using HarmonyLib;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.PlayerLayers.Roles.Roles;

namespace TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.CryomaniacMod
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Update))]
    public static class MeetingHUDUpdate
    {
        public static void Postfix(MeetingHud __instance)
        {
            var localPlayer = PlayerControl.LocalPlayer;
            var _role = Role.GetRole(localPlayer);

            if (_role?.RoleType != RoleEnum.Cryomaniac)
                return;

            if (localPlayer.Data.IsDead)
                return;

            var role = (Cryomaniac)_role;

            foreach (var state in __instance.playerStates)
            {
                var targetId = state.TargetPlayerId;
                var playerData = Utils.PlayerById(targetId)?.Data;

                if (playerData == null || playerData.Disconnected || playerData.IsDead)
                {
                    role.DousedPlayers.Remove(targetId);
                    continue;
                }

                if (role.DousedPlayers.Contains(targetId))
                    state.NameText.color = role.Color;
            }
        }
    }
}