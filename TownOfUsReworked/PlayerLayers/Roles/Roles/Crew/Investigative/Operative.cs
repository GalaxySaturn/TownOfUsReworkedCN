﻿using System;
using System.Collections.Generic;
using TownOfUsReworked.Objects;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Data;
using TMPro;

namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Operative : CrewRole
    {
        public List<Bug> Bugs = new();
        public DateTime LastBugged;
        public int UsesLeft;
        public List<RoleEnum> BuggedPlayers = new();
        public bool ButtonUsable => UsesLeft > 0;
        public AbilityButton BugButton;
        public Dictionary<byte, TMP_Text> PlayerNumbers = new();

        public Operative(PlayerControl player) : base(player)
        {
            Name = "Operative";
            StartText = "Detect Which Roles Are Here";
            AbilitiesText = "- You can place bugs around the map\n- Upon triggering the bugs, the player's role will be included in a list to be shown in the next meeting\n- " +
                "You can see which colors are where on the admin table\n- On Vitals, the time of death for each player will be shown";
            Color = CustomGameOptions.CustomCrewColors ? Colors.Operative : Colors.Crew;
            RoleType = RoleEnum.Operative;
            BuggedPlayers = new();
            UsesLeft = CustomGameOptions.MaxBugs;
            RoleAlignment = RoleAlignment.CrewInvest;
            AlignmentName = CI;
            Bugs = new();
            InspectorResults = InspectorResults.DropsItems;
            PlayerNumbers = new();
        }

        public float BugTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timespan = utcNow - LastBugged;
            var num = CustomButtons.GetModifiedCooldown(CustomGameOptions.BugCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }
    }
}
