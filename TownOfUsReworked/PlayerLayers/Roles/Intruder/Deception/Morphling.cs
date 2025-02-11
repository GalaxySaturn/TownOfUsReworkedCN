namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Morphling : Intruder
    {
        public CustomButton MorphButton;
        public CustomButton SampleButton;
        public DateTime LastMorphed;
        public DateTime LastSampled;
        public PlayerControl MorphedPlayer;
        public PlayerControl SampledPlayer;
        public float TimeRemaining;
        public bool Enabled;
        public bool Morphed => TimeRemaining > 0f;

        public Morphling(PlayerControl player) : base(player)
        {
            Name = "Morphling";
            StartText = () => "Fool The <color=#8CFFFFFF>Crew</color> With Your Appearances";
            AbilitiesText = () => $"- You can morph into other players, taking up their appearances as your own\n{CommonAbilities}";
            Color = CustomGameOptions.CustomIntColors ? Colors.Morphling : Colors.Intruder;
            RoleType = RoleEnum.Morphling;
            RoleAlignment = RoleAlignment.IntruderDecep;
            SampledPlayer = null;
            MorphedPlayer = null;
            Type = LayerEnum.Morphling;
            MorphButton = new(this, "Morph", AbilityTypes.Effect, "Secondary", HitMorph);
            SampleButton = new(this, "Sample", AbilityTypes.Direct, "Tertiary", Sample, Exception1);
            InspectorResults = InspectorResults.CreatesConfusion;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        public void Morph()
        {
            TimeRemaining -= Time.deltaTime;
            Utils.Morph(Player, MorphedPlayer);
            Enabled = true;

            if (IsDead || Utils.Meeting)
                TimeRemaining = 0f;
        }

        public void Unmorph()
        {
            MorphedPlayer = null;
            Enabled = false;
            Utils.DefaultOutfit(Player);
            LastMorphed = DateTime.UtcNow;

            if (CustomGameOptions.MorphCooldownsLinked)
                LastSampled = DateTime.UtcNow;
        }

        public float MorphTimer()
        {
            var timespan = DateTime.UtcNow - LastMorphed;
            var num = Player.GetModifiedCooldown(CustomGameOptions.MorphlingCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public float SampleTimer()
        {
            var timespan = DateTime.UtcNow - LastSampled;
            var num = Player.GetModifiedCooldown(CustomGameOptions.SampleCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void HitMorph()
        {
            if (MorphTimer() != 0f || SampledPlayer == null || Morphed)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.Morph);
            writer.Write(PlayerId);
            writer.Write(SampledPlayer.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            TimeRemaining = CustomGameOptions.MorphlingDuration;
            MorphedPlayer = SampledPlayer;
            Morph();
        }

        public void Sample()
        {
            if (SampleTimer() != 0f || Utils.IsTooFar(Player, SampleButton.TargetPlayer) || SampledPlayer == SampleButton.TargetPlayer)
                return;

            var interact = Utils.Interact(Player, SampleButton.TargetPlayer);

            if (interact[3])
                SampledPlayer = SampleButton.TargetPlayer;

            if (interact[0])
            {
                LastSampled = DateTime.UtcNow;

                if (CustomGameOptions.MorphCooldownsLinked)
                    LastMorphed = DateTime.UtcNow;
            }
            else if (interact[1])
            {
                LastSampled.AddSeconds(CustomGameOptions.ProtectKCReset);

                if (CustomGameOptions.MorphCooldownsLinked)
                    LastMorphed.AddSeconds(CustomGameOptions.ProtectKCReset);
            }
        }

        public bool Exception1(PlayerControl player) => player == SampledPlayer;

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            MorphButton.Update("MORPH", MorphTimer(), CustomGameOptions.MorphlingCd, Morphed, TimeRemaining, CustomGameOptions.MorphlingDuration, true, SampledPlayer != null);
            SampleButton.Update("SAMPLE", SampleTimer(), CustomGameOptions.MeasureCooldown);
        }
    }
}
