﻿using System;
using System.Collections.Generic;
using System.Linq;
using Hazel;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Classes;
using UnityEngine;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Arsonist : NeutralRole
    {
        public AbilityButton IgniteButton;
        public AbilityButton DouseButton;
        public bool LastKiller => !PlayerControl.AllPlayerControls.Any(x => !x.Data.IsDead && !x.Data.Disconnected && (x.Is(Faction.Intruder) || x.Is(Faction.Syndicate) ||
            x.Is(RoleAlignment.CrewKill) || x.Is(RoleAlignment.CrewAudit) || x.Is(RoleAlignment.NeutralPros) || (x.Is(RoleAlignment.NeutralKill) && x != Player)));
        public PlayerControl ClosestPlayer;
        public List<byte> DousedPlayers = new();
        public DateTime LastDoused;
        public DateTime LastIgnited;
        public int DousedAlive => DousedPlayers.Count;

        public Arsonist(PlayerControl player) : base(player)
        {
            Name = "Arsonist";
            StartText = "Gasoline + Bean + Lighter = Bonfire";
            AbilitiesText = "- You can douse players in gasoline\n- Doused players can be ignited, killing them all at once\n- People who interact with you will also get doused";
            Objectives = "- Burn anyone who can oppose you";
            RoleType = RoleEnum.Arsonist;
            RoleAlignment = RoleAlignment.NeutralKill;
            AlignmentName = NK;
            Color = CustomGameOptions.CustomNeutColors ? Colors.Arsonist : Colors.Neutral;
            DousedPlayers = new();
        }

        public float DouseTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timespan = utcNow - LastDoused;
            var num = CustomButtons.GetModifiedCooldown(CustomGameOptions.DouseCd) * 1000f;
            var flag2 = num - (float) timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float) timespan.TotalMilliseconds) / 1000f;
        }

        public float IgniteTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timespan = utcNow - LastIgnited;
            var num = CustomGameOptions.IgniteCd * 1000f;
            var flag2 = num - (float) timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float) timespan.TotalMilliseconds) / 1000f;
        }

        public void Ignite()
        {
            foreach (var arso in GetRoles<Arsonist>(RoleEnum.Arsonist))
            {
                if (arso.Player != Player && !CustomGameOptions.ArsoIgniteAll)
                    continue;

                foreach (var playerId in arso.DousedPlayers)
                {
                    var player = Utils.PlayerById(playerId);

                    if (player?.Data.Disconnected == true || player.Data.IsDead || player.Is(RoleEnum.Pestilence) || player.IsProtected())
                        continue;

                    Utils.RpcMurderPlayer(Player, player, false);
                }

                arso.DousedPlayers.Clear();
            }
        }

        public void RpcSpreadDouse(PlayerControl source, PlayerControl target)
        {
            _ = new WaitForSeconds(1f);

            if (!source.Is(RoleType))
                return;

            DousedPlayers.Add(target.PlayerId);
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.Douse);
            writer.Write(Player.PlayerId);
            writer.Write(target.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
    }
}
