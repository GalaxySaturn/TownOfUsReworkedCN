namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Survivor : Neutral
    {
        public bool Enabled;
        public DateTime LastVested;
        public float TimeRemaining;
        public int UsesLeft;
        public bool ButtonUsable => UsesLeft > 0;
        public bool Vesting => TimeRemaining > 0f;
        public bool Alive => !Disconnected && !IsDead;
        public CustomButton VestButton;

        public Survivor(PlayerControl player) : base(player)
        {
            Name = "Survivor";
            StartText = () => "Do Whatever It Takes To Live";
            AbilitiesText = () => "- You can put on a vest, which makes you unkillable for a short duration of time";
            Color = CustomGameOptions.CustomNeutColors ? Colors.Survivor : Colors.Neutral;
            RoleType = RoleEnum.Survivor;
            UsesLeft = CustomGameOptions.MaxVests;
            RoleAlignment = RoleAlignment.NeutralBen;
            Objectives = () => "- Live to the end of the game";
            InspectorResults = InspectorResults.LeadsTheGroup;
            Type = LayerEnum.Survivor;
            VestButton = new(this, "Vest", AbilityTypes.Effect, "ActionSecondary", HitVest, true);

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        public float VestTimer()
        {
            var timespan = DateTime.UtcNow - LastVested;
            var num = Player.GetModifiedCooldown(CustomGameOptions.VestCd) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Vest()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            if (Utils.Meeting)
                TimeRemaining = 0f;
        }

        public void UnVest()
        {
            Enabled = false;
            LastVested = DateTime.UtcNow;
        }

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            VestButton.Update("PROTECT", VestTimer(), CustomGameOptions.VestCd, UsesLeft, Vesting, TimeRemaining, CustomGameOptions.VestDuration);
        }

        public void HitVest()
        {
            if (!ButtonUsable || VestTimer() != 0f || Vesting)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.Vest);
            writer.Write(CustomPlayer.Local.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            TimeRemaining = CustomGameOptions.VestDuration;
            UsesLeft--;
            Vest();
        }
    }
}