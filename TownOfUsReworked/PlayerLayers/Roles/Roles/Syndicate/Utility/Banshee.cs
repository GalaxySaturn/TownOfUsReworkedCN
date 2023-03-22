using TownOfUsReworked.Enums;
using TownOfUsReworked.Classes;
using System;
using TownOfUsReworked.CustomOptions;
using UnityEngine;
using System.Collections.Generic;

namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Banshee : SyndicateRole
    {
        public AbilityButton ScreamButton;
        public bool Enabled;
        public DateTime LastScreamed;
        public float TimeRemaining;
        public bool Screaming => TimeRemaining > 0f;
        public List<byte> Blocked;
        public bool Caught;
        public bool Faded;

        public Banshee(PlayerControl player) : base(player)
        {
            Name = "Banshee";
            RoleType = RoleEnum.Banshee;
            StartText = "Scream";
            RoleAlignment = RoleAlignment.SyndicateUtil;
            AlignmentName = SSu;
            InspectorResults = InspectorResults.Ghostly;
            Color = CustomGameOptions.CustomSynColors ? Colors.Banshee : Colors.Syndicate;
            Blocked = new();
        }

        public void Scream()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            if (MeetingHud.Instance)
                TimeRemaining = 0f;
        }

        public void UnScream()
        {
            Enabled = false;
            LastScreamed = DateTime.UtcNow;

            foreach (var id in Blocked)
            {
                var player = Utils.PlayerById(id);

                if (player == null || player.Data.Disconnected)
                    continue;

                var targetRole = GetRole(player);
                targetRole.IsBlocked = false;
            }

            Blocked.Clear();
        }

        public float ScreamTimer()
        {
            var utcNow = DateTime.UtcNow;
            var timeSpan = utcNow - LastScreamed;
            var num = CustomGameOptions.ScreamCooldown * 1000f;
            var flag2 = num - (float) timeSpan.TotalMilliseconds < 0f;

            if (flag2)
                return 0f;

            return (num - (float) timeSpan.TotalMilliseconds) / 1000f;
        }

        public void Fade()
        {
            Faded = true;
            Player.Visible = true;
            var color = new Color(1f, 1f, 1f, 0f);

            var maxDistance = ShipStatus.Instance.MaxLightRadius * GameOptionsManager.Instance.currentNormalGameOptions.CrewLightMod;
            var distance = (PlayerControl.LocalPlayer.GetTruePosition() - Player.GetTruePosition()).magnitude;

            var distPercent = distance / maxDistance;
            distPercent = Mathf.Max(0, distPercent - 1);

            var velocity = Player.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            color.a = 0.07f + velocity / Player.MyPhysics.TrueSpeed * 0.13f;
            color.a = Mathf.Lerp(color.a, 0, distPercent);

            if (Player.GetCustomOutfitType() != CustomPlayerOutfitType.PlayerNameOnly)
            {
                Player.SetOutfit(CustomPlayerOutfitType.PlayerNameOnly, new GameData.PlayerOutfit()
                {
                    ColorId = Player.GetDefaultOutfit().ColorId,
                    HatId = "",
                    SkinId = "",
                    VisorId = "",
                    PlayerName = ""
                });
            }

            Player.myRend().color = color;
            Player.NameText().color = new Color(0f, 0f, 0f, 0f);
            Player.cosmetics.colorBlindText.color = new Color(0f, 0f, 0f, 0f);
        }
    }
}