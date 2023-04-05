using TownOfUsReworked.Data;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Modules;
using System;

namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Engineer : CrewRole
    {
        public AbilityButton FixButton;
        public int UsesLeft = CustomGameOptions.MaxFixes;
        public bool ButtonUsable => UsesLeft > 0;
        public DateTime LastFixed;

        public Engineer(PlayerControl player) : base(player)
        {
            Name = "Engineer";
            StartText = "Just Fix It";
            AbilitiesText = "- You can fix sabotages at any time during the game\n- You can vent";
            Color = CustomGameOptions.CustomCrewColors ? Colors.Engineer : Colors.Crew;
            RoleType = RoleEnum.Engineer;
            RoleAlignment = RoleAlignment.CrewSupport;
            AlignmentName = CS;
            InspectorResults = InspectorResults.DifferentLens;
        }

        public float FixTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timespan = utcNow - LastFixed;
            var num = CustomButtons.GetModifiedCooldown(CustomGameOptions.FixCooldown) * 1000f;
            var flag2 = num - (float) timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float) timespan.TotalMilliseconds) / 1000f;
        }
    }
}