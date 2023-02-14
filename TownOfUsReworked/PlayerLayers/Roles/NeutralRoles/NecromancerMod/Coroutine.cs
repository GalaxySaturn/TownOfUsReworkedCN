using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reactor.Utilities.Extensions;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Classes;
using TownOfUsReworked.Lobby.CustomOption;
using TownOfUsReworked.PlayerLayers.Roles.Roles;
using TownOfUsReworked.Patches;
using UnityEngine;
using Object = UnityEngine.Object;
using TownOfUsReworked.PlayerLayers.Objectifiers;
using TownOfUsReworked.PlayerLayers.Objectifiers.Objectifiers;
using AmongUs.GameOptions;

namespace TownOfUsReworked.PlayerLayers.Roles.NeutralRoles.NecromancerMod
{
    public class Coroutine
    {
        public static IEnumerator NecromancerResurrect(DeadBody target, Necromancer role)
        {
            var parentId = target.ParentId;
            var position = target.TruePosition;
            role.Resurrecting = true;

            var revived = new List<PlayerControl>();

            if (CustomGameOptions.NecromancerTargetBody)
            {
                foreach (DeadBody deadBody in GameObject.FindObjectsOfType<DeadBody>())
                {
                    if (deadBody.ParentId == parentId)
                        deadBody.gameObject.Destroy();
                }
            }

            var startTime = DateTime.UtcNow;

            while (true)
            {
                var now = DateTime.UtcNow;
                var seconds = (now - startTime).TotalSeconds;

                if (seconds < CustomGameOptions.NecroResurrectDuration)
                    yield return null;
                else
                    break;

                if (MeetingHud.Instance)
                {
                    role.Resurrecting = false;
                    yield break;
                }
            }

            foreach (DeadBody deadBody in GameObject.FindObjectsOfType<DeadBody>())
            {
                if (deadBody.ParentId == role.Player.PlayerId)
                    deadBody.gameObject.Destroy();
            }

            var player = Utils.PlayerById(parentId);

            var targetRole = Role.GetRole(player);
            targetRole.DeathReason = DeathReasonEnum.Revived;
            targetRole.KilledBy = " By " + role.PlayerName;
            targetRole.SubFaction = SubFaction.Reanimated;
            targetRole.IsResurrected = true;

            foreach (var poisoner in Role.GetRoles(RoleEnum.Poisoner))
            {
                var poisonerRole = (Poisoner)poisoner;

                if (poisonerRole.PoisonedPlayer == player)
                    poisonerRole.PoisonedPlayer = poisonerRole.Player;
            }

            player.Revive();

            if (player.Data.IsImpostor())
                RoleManager.Instance.SetRole(player, RoleTypes.Impostor);
            else
                RoleManager.Instance.SetRole(player, RoleTypes.Crewmate);

            Murder.KilledPlayers.Remove(Murder.KilledPlayers.FirstOrDefault(x => x.PlayerId == player.PlayerId));
            revived.Add(player);
            player.NetTransform.SnapTo(new Vector2(position.x, position.y + 0.3636f));

            if (PlayerControl.LocalPlayer == player)
            {
                try
                {
                    //SoundManager.Instance.PlaySound(TownOfUsReworked.ReviveSound, false, 1f);
                } catch {}
            }

            if (SubmergedCompatibility.isSubmerged() && PlayerControl.LocalPlayer.PlayerId == player.PlayerId)
                SubmergedCompatibility.ChangeFloor(player.transform.position.y > -7);

            if (target != null)
                Object.Destroy(target.gameObject);

            if (player.Is(ObjectifierEnum.Lovers) && CustomGameOptions.BothLoversDie)
            {
                var lover = Objectifier.GetObjectifier<Lovers>(player).OtherLover;

                lover.Revive();
                Murder.KilledPlayers.Remove(Murder.KilledPlayers.FirstOrDefault(x => x.PlayerId == lover.PlayerId));
                revived.Add(lover);

                foreach (DeadBody deadBody in GameObject.FindObjectsOfType<DeadBody>())
                {
                    if (deadBody.ParentId == lover.PlayerId)
                        deadBody.gameObject.Destroy();
                }

                var loverRole = Role.GetRole(lover);
                loverRole.DeathReason = DeathReasonEnum.Revived;
                loverRole.KilledBy = " By " + role.PlayerName;
                loverRole.SubFaction = SubFaction.Reanimated;
                loverRole.IsResurrected = true;
            }

            if (revived.Any(x => x.AmOwner))
            {
                Minigame.Instance.Close();
                Minigame.Instance.Close();
            }

            Utils.Spread(role.Player, player);
        }
    }
}