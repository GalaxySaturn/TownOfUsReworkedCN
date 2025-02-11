namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Banshee : Syndicate
    {
        public CustomButton ScreamButton;
        public bool Enabled;
        public DateTime LastScreamed;
        public float TimeRemaining;
        public bool Screaming => TimeRemaining > 0f;
        public List<byte> Blocked = new();
        public bool Caught;
        public bool Faded;

        public Banshee(PlayerControl player) : base(player)
        {
            Name = "Banshee";
            RoleType = RoleEnum.Banshee;
            StartText = () => "AAAAAAAAAAAAAAAAAAAAAAAAA";
            AbilitiesText = () => "- You can scream loudly, blocking all players as long as you are not clicked";
            RoleAlignment = RoleAlignment.SyndicateUtil;
            Color = CustomGameOptions.CustomSynColors ? Colors.Banshee : Colors.Syndicate;
            Blocked = new();
            Type = LayerEnum.Banshee;
            RoleBlockImmune = true; //Not taking chances
            ScreamButton = new(this, "Scream", AbilityTypes.Effect, "ActionSecondary", HitScream);
            InspectorResults = InspectorResults.Ghostly;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        public void Scream()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            foreach (var id in Blocked)
            {
                var player = Utils.PlayerById(id);

                foreach (var layer in GetLayers(player))
                    layer.IsBlocked = !GetRole(player).RoleBlockImmune;
            }

            if (Utils.Meeting || Caught)
                TimeRemaining = 0f;
        }

        public void UnScream()
        {
            Enabled = false;
            LastScreamed = DateTime.UtcNow;

            foreach (var id in Blocked)
            {
                var player = Utils.PlayerById(id);

                if (player?.Data.Disconnected == true)
                    continue;

                foreach (var layer in GetLayers(player))
                    layer.IsBlocked = false;
            }

            Blocked.Clear();
        }

        public float ScreamTimer()
        {
            var timespan = DateTime.UtcNow - LastScreamed;
            var num = CustomGameOptions.ScreamCooldown * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Fade()
        {
            Faded = true;
            Player.Visible = true;
            var color = new Color(1f, 1f, 1f, 0f);

            var maxDistance = ShipStatus.Instance.MaxLightRadius * TownOfUsReworked.VanillaOptions.CrewLightMod;
            var distance = (CustomPlayer.Local.GetTruePosition() - Player.GetTruePosition()).magnitude;

            var distPercent = distance / maxDistance;
            distPercent = Mathf.Max(0, distPercent - 1);

            var velocity = Player.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            color.a = 0.07f + (velocity / Player.MyPhysics.TrueSpeed * 0.13f);
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

            Player.MyRend().color = color;
            Player.NameText().color = new(0f, 0f, 0f, 0f);
            Player.cosmetics.colorBlindText.color = new(0f, 0f, 0f, 0f);
        }

        public void HitScream()
        {
            if (ScreamTimer() != 0f)
                return;

            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.Scream);
            writer.Write(PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
            TimeRemaining = CustomGameOptions.ScreamDuration;
            Scream();

            foreach (var player in CustomPlayer.AllPlayers)
            {
                if (!player.Data.IsDead && !player.Data.Disconnected && !player.Is(Faction.Syndicate))
                    Blocked.Add(player.PlayerId);
            }
        }

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            ScreamButton.Update("SCREAM", ScreamTimer(), CustomGameOptions.ScreamCooldown, Screaming, TimeRemaining, CustomGameOptions.ScreamDuration, true, !Caught);
        }
    }
}