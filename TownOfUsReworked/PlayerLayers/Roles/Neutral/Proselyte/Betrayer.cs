namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Betrayer : Neutral
    {
        public CustomButton KillButton;
        public DateTime LastKilled;

        public Betrayer(PlayerControl player) : base(player)
        {
            Name = "Betrayer";
            StartText = () => "Those Guys Backs Are Ripe For Some Backstabbing";
            Objectives = () => $"- Kill anyone who opposes the {FactionName}";
            RoleType = RoleEnum.Betrayer;
            Color = CustomGameOptions.CustomNeutColors ? Colors.Betrayer : Colors.Neutral;
            RoleAlignment = RoleAlignment.NeutralPros;
            Type = LayerEnum.Betrayer;
            KillButton = new(this, "BetKill", AbilityTypes.Direct, "ActionSecondary", Kill, Exception);
            InspectorResults = InspectorResults.IsAggressive;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        public float KillTimer()
        {
            var timespan = DateTime.UtcNow - LastKilled;
            var num = Player.GetModifiedCooldown(CustomGameOptions.BetrayerKillCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Kill()
        {
            if (Utils.IsTooFar(Player, KillButton.TargetPlayer) || KillTimer() != 0f || Faction == Faction.Neutral)
                return;

            var interact = Utils.Interact(Player, KillButton.TargetPlayer, true);

            if (interact[3] || interact[0])
                LastKilled = DateTime.UtcNow;
            else if (interact[1])
                LastKilled.AddSeconds(CustomGameOptions.ProtectKCReset);
            else if (interact[2])
                LastKilled.AddSeconds(CustomGameOptions.VestKCReset);
        }

        public bool Exception(PlayerControl player) => (player.Is(SubFaction) && SubFaction != SubFaction.None) || (player.Is(Faction) && Faction is Faction.Intruder or
            Faction.Syndicate) || player == Player.GetOtherLover() || player == Player.GetOtherRival();

        public override void UpdateHud(HudManager __instance)
        {
            if (Faction == Faction.Neutral)
                return;

            base.UpdateHud(__instance);
            KillButton.Update("KILL", KillTimer(), CustomGameOptions.BetrayerKillCooldown);
        }
    }
}