﻿using System.Collections.Generic;
using Hazel;
using TownOfUsReworked.Patches;
using UnityEngine;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.Lobby.CustomOption;
using TownOfUsReworked.Enums;

namespace TownOfUsReworked.PlayerLayers.Objectifiers.Objectifiers
{
    public class Lovers : Objectifier
    {
        public PlayerControl OtherLover { get; set; }
        public bool LoveWins { get; set; }

        public Lovers(PlayerControl player) : base(player)
        {
            Name = "Lover";
            SymbolName = "♥";
            TaskText = "You are in Love";
            Color = CustomGameOptions.CustomObjectifierColors ? Colors.Lovers : Colors.Objectifier;
            ObjectifierType = ObjectifierEnum.Lovers;
        }

        public static void Gen(List<PlayerControl> canHaveObjectifiers)
        {
            List<PlayerControl> all = new List<PlayerControl>();

            foreach (var player in canHaveObjectifiers)
                all.Add(player);

            if (all.Count < 3)
                return;

            PlayerControl firstLover = null;
            PlayerControl secondLover = null;
            
            while (firstLover == null || secondLover == null || firstLover == secondLover || (firstLover.GetFaction() == secondLover.GetFaction() && !CustomGameOptions.LoversFaction))
            {
                all.Shuffle();

                var num = Random.RandomRangeInt(0, all.Count);
                firstLover = all[num];

                var num2 = Random.RandomRangeInt(0, all.Count);
                secondLover = all[num2];
            }

            canHaveObjectifiers.Remove(firstLover);
            canHaveObjectifiers.Remove(secondLover);

            var lover1 = new Lovers(firstLover);
            var lover2 = new Lovers(secondLover);

            lover1.OtherLover = lover2.Player;
            lover2.OtherLover = lover1.Player;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetCouple, SendOption.Reliable, -1);
            writer.Write(firstLover.PlayerId);
            writer.Write(secondLover.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }

        internal override bool EABBNOODFGL(ShipStatus __instance)
        {
            if (LoverDead())
                return true;

            if (Utils.LoversWin(ObjectifierType))
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) CustomRPC.LoveWin, SendOption.Reliable, -1);
                writer.Write(Player.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                Wins();
                Utils.EndGame();
                return false;
            }

            return false;
        }

        public bool LoverDead()
        {
            PlayerControl lover1 = Player;
            PlayerControl lover2 = OtherLover;
            
            return lover1 != null && lover2 != null && ((lover1.Data.IsDead && lover1.Data.Disconnected) || (lover2.Data.Disconnected || lover2.Data.IsDead));
        }

        public override void Wins()
        {
            LoveWins = true;
        }
    }
}