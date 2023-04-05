﻿using System;
using System.Collections.Generic;
using Hazel;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Classes;
using UnityEngine;
using System.Linq;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Cryomaniac : NeutralRole
    {
        public AbilityButton FreezeButton;
        public AbilityButton DouseButton;
        public PlayerControl ClosestPlayer;
        public List<byte> DousedPlayers;
        public bool FreezeUsed;
        public DateTime LastDoused;
        public bool LastKiller => !PlayerControl.AllPlayerControls.Any(x => !x.Data.IsDead && !x.Data.Disconnected && (x.Is(Faction.Intruder) || x.Is(Faction.Syndicate) ||
            x.Is(RoleAlignment.CrewKill) || x.Is(RoleAlignment.CrewAudit) || x.Is(RoleAlignment.NeutralPros) || (x.Is(RoleAlignment.NeutralKill) && x != Player)));
        public int DousedAlive => DousedPlayers.Count(x => Utils.PlayerById(x)?.Data?.IsDead == false && Utils.PlayerById(x)?.Data?.Disconnected == false);

        public Cryomaniac(PlayerControl player) : base(player)
        {
            Name = "Cryomaniac";
            StartText = "Who Likes Ice Cream?";
            AbilitiesText = "- You can douse players in coolant\n- Doused players can be frozen, which kills all of them at once at the start of the next meeting\n- People who " +
                "interact with you will also get doused";
            Objectives = "- Freeze anyone who can oppose you";
            Color = CustomGameOptions.CustomNeutColors ? Colors.Cryomaniac : Colors.Neutral;
            RoleType = RoleEnum.Cryomaniac;
            RoleAlignment = RoleAlignment.NeutralKill;
            AlignmentName = NK;
            DousedPlayers = new List<byte>();
        }

        public float DouseTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timespan = utcNow - LastDoused;
            var num = CustomButtons.GetModifiedCooldown(CustomGameOptions.DouseCd) * 1000f;
            var flag2 = num - (float) timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float) timespan.TotalMilliseconds) / 1000f;
        }

        public void RpcSpreadDouse(PlayerControl source, PlayerControl target)
        {
            _ = new WaitForSeconds(1f);

            if (!source.Is(RoleType))
                return;

            DousedPlayers.Add(target.PlayerId);
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.FreezeDouse);
            writer.Write(Player.PlayerId);
            writer.Write(target.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
    }
}
