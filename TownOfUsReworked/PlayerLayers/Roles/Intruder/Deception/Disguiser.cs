namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Disguiser : Intruder
    {
        public CustomButton DisguiseButton;
        public CustomButton MeasureButton;
        public DateTime LastDisguised;
        public DateTime LastMeasured;
        public float TimeRemaining;
        public float TimeRemaining2;
        public PlayerControl MeasuredPlayer;
        public PlayerControl DisguisePlayer;
        public PlayerControl DisguisedPlayer;
        public bool DelayActive => TimeRemaining2 > 0f;
        public bool Disguised => TimeRemaining > 0f;
        public bool Enabled;

        public Disguiser(PlayerControl player) : base(player)
        {
            Name = "Disguiser";
            StartText = () => "Disguise The <color=#8CFFFFFF>Crew</color> To Frame Them";
            AbilitiesText = () => $"- You can disguise a player into someone else's appearance\n{CommonAbilities}";
            Color = CustomGameOptions.CustomIntColors ? Colors.Disguiser : Colors.Intruder;
            RoleType = RoleEnum.Disguiser;
            RoleAlignment = RoleAlignment.IntruderDecep;
            MeasuredPlayer = null;
            Type = LayerEnum.Disguiser;
            DisguiseButton = new(this, "Disguise", AbilityTypes.Direct, "Secondary", HitDisguise, Exception1);
            MeasureButton = new(this, "Measure", AbilityTypes.Direct, "Tertiary", Measure, Exception2);
            DisguisePlayer = null;
            DisguisedPlayer = null;
            InspectorResults = InspectorResults.CreatesConfusion;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        public void Disguise()
        {
            TimeRemaining -= Time.deltaTime;
            Utils.Morph(DisguisedPlayer, DisguisePlayer);
            Enabled = true;

            if (IsDead || DisguisedPlayer.Data.IsDead || DisguisedPlayer.Data.Disconnected || Utils.Meeting)
                TimeRemaining = 0f;
        }

        public void Delay()
        {
            TimeRemaining2 -= Time.deltaTime;

            if (IsDead || DisguisedPlayer.Data.IsDead || DisguisedPlayer.Data.Disconnected)
                TimeRemaining2 = 0f;
        }

        public void UnDisguise()
        {
            Enabled = false;
            Utils.DefaultOutfit(DisguisedPlayer);
            LastDisguised = DateTime.UtcNow;

            if (CustomGameOptions.DisgCooldownsLinked)
                LastMeasured = DateTime.UtcNow;
        }

        public float DisguiseTimer()
        {
            var timespan = DateTime.UtcNow - LastDisguised;
            var num = Player.GetModifiedCooldown(CustomGameOptions.DisguiseCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public float MeasureTimer()
        {
            var timespan = DateTime.UtcNow - LastMeasured;
            var num = Player.GetModifiedCooldown(CustomGameOptions.MeasureCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void HitDisguise()
        {
            if (DisguiseTimer() != 0f || Utils.IsTooFar(Player, DisguiseButton.TargetPlayer) || DisguiseButton.TargetPlayer == MeasuredPlayer || Disguised || DelayActive)
                return;

            var interact = Utils.Interact(Player, DisguiseButton.TargetPlayer);

            if (interact[3])
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.Disguise);
                writer.Write(PlayerId);
                writer.Write(MeasuredPlayer.PlayerId);
                writer.Write(DisguiseButton.TargetPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                TimeRemaining = CustomGameOptions.DisguiseDuration;
                TimeRemaining2 = CustomGameOptions.TimeToDisguise;
                DisguisePlayer = MeasuredPlayer;
                DisguisedPlayer = DisguiseButton.TargetPlayer;
                Delay();

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastMeasured = DateTime.UtcNow;
            }
            else if (interact[0])
            {
                LastDisguised = DateTime.UtcNow;

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastMeasured = DateTime.UtcNow;
            }
            else if (interact[1])
            {
                LastDisguised.AddSeconds(CustomGameOptions.ProtectKCReset);

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastMeasured.AddSeconds(CustomGameOptions.ProtectKCReset);
            }
        }

        public void Measure()
        {
            if (MeasureTimer() != 0f || Utils.IsTooFar(Player, MeasureButton.TargetPlayer) || MeasureButton.TargetPlayer == MeasuredPlayer)
                return;

            var interact = Utils.Interact(Player, MeasureButton.TargetPlayer);

            if (interact[3])
                MeasuredPlayer = MeasureButton.TargetPlayer;

            if (interact[0])
            {
                LastMeasured = DateTime.UtcNow;

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastDisguised = DateTime.UtcNow;
            }
            else if (interact[1])
            {
                LastMeasured.AddSeconds(CustomGameOptions.ProtectKCReset);

                if (CustomGameOptions.DisgCooldownsLinked)
                    LastDisguised.AddSeconds(CustomGameOptions.ProtectKCReset);
            }
        }

        public bool Exception1(PlayerControl player) => (player.Is(Faction) && CustomGameOptions.DisguiseTarget == DisguiserTargets.NonIntruders) || (!player.Is(Faction) &&
            CustomGameOptions.DisguiseTarget == DisguiserTargets.Intruders) || Exception2(player);

        public bool Exception2(PlayerControl player) => player == MeasuredPlayer;

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            DisguiseButton.Update("DISGUISE", DisguiseTimer(), CustomGameOptions.DisguiseCooldown, DelayActive || Disguised, DelayActive ? TimeRemaining2 : TimeRemaining,
                DelayActive ? CustomGameOptions.TimeToDisguise : CustomGameOptions.DisguiseDuration, true, MeasuredPlayer != null);
            MeasureButton.Update("MEASURE", MeasureTimer(), CustomGameOptions.MeasureCooldown);
        }
    }
}