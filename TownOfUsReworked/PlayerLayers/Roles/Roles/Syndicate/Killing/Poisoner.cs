using System;
using UnityEngine;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Classes;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Extensions;
using TownOfUsReworked.Data;
using TownOfUsReworked.Custom;
using Hazel;
using System.Linq;

namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Poisoner : SyndicateRole
    {
        public CustomButton PoisonButton;
        public CustomButton GlobalPoisonButton;
        public DateTime LastPoisoned;
        public PlayerControl PoisonedPlayer;
        public PlayerControl ClosestPoison;
        public float TimeRemaining;
        public bool Enabled;
        public bool Poisoned => TimeRemaining > 0f;
        public CustomMenu PoisonMenu;

        public Poisoner(PlayerControl player) : base(player)
        {
            Name = "Poisoner";
            StartText = "Delay A Kill To Decieve The <color=#8BFDFDFF>Crew</color>";
            AbilitiesText = $"- You can poison players\n- Poisoned players will die after {CustomGameOptions.PoisonDuration}s\n- With the Chaos Drive, you can poison players from anywhere"
                + $"occur concurrently\n{AbilitiesText}";
            Color = CustomGameOptions.CustomIntColors? Colors.Poisoner : Colors.Syndicate;
            RoleType = RoleEnum.Poisoner;
            PoisonedPlayer = null;
            RoleAlignment = RoleAlignment.SyndicateKill;
            AlignmentName = SyK;
            PoisonMenu = new(Player, Click);
            PoisonedPlayer = null;
            Type = LayerEnum.Poisoner;
            PoisonButton = new(this, AssetManager.Poison, AbilityTypes.Direct, "ActionSecondary", HitPoison);
            GlobalPoisonButton = new(this, AssetManager.Poison, AbilityTypes.Effect, "ActionSecondary", HitGlobalPoison);
        }

        public void Poison()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            if (MeetingHud.Instance || PoisonedPlayer.Data.IsDead || PoisonedPlayer.Data.Disconnected || Player.Data.IsDead)
                TimeRemaining = 0f;
        }

        public void PoisonKill()
        {
            if (!(PoisonedPlayer.Data.IsDead || PoisonedPlayer.Data.Disconnected || PoisonedPlayer.Is(RoleEnum.Pestilence)))
            {
                Utils.RpcMurderPlayer(Player, PoisonedPlayer, DeathReasonEnum.Poisoned, false);

                if (!PoisonedPlayer.Data.IsDead)
                {
                    try
                    {
                        SoundManager.Instance.PlaySound(PlayerControl.LocalPlayer.KillSfx, false, 1f);
                    } catch {}
                }
            }

            PoisonedPlayer = null;
            Enabled = false;
            LastPoisoned = DateTime.UtcNow;
        }

        public float PoisonTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timespan = utcNow - LastPoisoned;
            var num = Player.GetModifiedCooldown(CustomGameOptions.PoisonCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Click(PlayerControl player)
        {
            var interact = Utils.Interact(Player, player);

            if (interact[3])
                PoisonedPlayer = player;
            else if (interact[0])
                LastPoisoned = DateTime.UtcNow;
            else if (interact[1])
                LastPoisoned.AddSeconds(CustomGameOptions.ProtectKCReset);
        }

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            var notSyn = PlayerControl.AllPlayerControls.ToArray().Where(x => !x.Is(Faction.Syndicate) && x != PoisonedPlayer).ToList();
            var flag = PoisonedPlayer == null && HoldsDrive;
            GlobalPoisonButton.Update(flag ? "SET TARGET" : "POISON", PoisonTimer(), CustomGameOptions.PoisonCd, Poisoned, TimeRemaining, CustomGameOptions.PoisonDuration);
            PoisonButton.Update("POISON", PoisonTimer(), CustomGameOptions.PoisonCd, notSyn, Poisoned, TimeRemaining, CustomGameOptions.PoisonDuration);

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (PoisonedPlayer != null && HoldsDrive && !Poisoned)
                    PoisonedPlayer = null;

                Utils.LogSomething("Removed a target");
            }
        }

        public void HitPoison()
        {
            if (PoisonTimer() != 0f || Poisoned || HoldsDrive || Utils.IsTooFar(Player, ClosestPlayer))
                return;

            var interact = Utils.Interact(Player, ClosestPlayer);

            if (interact[3])
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.Poison);
                writer.Write(Player.PlayerId);
                writer.Write(ClosestPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                PoisonedPlayer = ClosestPlayer;
                TimeRemaining = CustomGameOptions.PoisonDuration;
                Poison();
            }
            else if (interact[0])
                LastPoisoned = DateTime.UtcNow;
            else if (interact[1])
                LastPoisoned.AddSeconds(CustomGameOptions.ProtectKCReset);
            else if (interact[2])
                LastPoisoned.AddSeconds(CustomGameOptions.VestKCReset);
        }

        public void HitGlobalPoison()
        {
            if (PoisonTimer() != 0f || Poisoned || !HoldsDrive)
                return;

            if (PoisonedPlayer == null)
                PoisonMenu.Open(PlayerControl.AllPlayerControls.ToArray().Where(x => !x.Is(Faction.Syndicate) && x != PoisonedPlayer).ToList());
            else
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.Poison);
                writer.Write(Player.PlayerId);
                writer.Write(PoisonedPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                TimeRemaining = CustomGameOptions.PoisonDuration;
                Poison();
            }
        }
    }
}