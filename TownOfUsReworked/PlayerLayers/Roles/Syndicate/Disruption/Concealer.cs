namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Concealer : Syndicate
    {
        public CustomButton ConcealButton;
        public bool Enabled;
        public DateTime LastConcealed;
        public float TimeRemaining;
        public bool Concealed => TimeRemaining > 0f;
        public PlayerControl ConcealedPlayer;
        public CustomMenu ConcealMenu;

        public Concealer(PlayerControl player) : base(player)
        {
            Name = "Concealer";
            StartText = () => "Make The <color=#8CFFFFFF>Crew</color> Invisible For Some Chaos";
            AbilitiesText = () => $"- You can make a player invisible\n- With the Chaos Drive, you make everyone invisible\n{CommonAbilities}";
            Color = CustomGameOptions.CustomSynColors ? Colors.Concealer : Colors.Syndicate;
            RoleType = RoleEnum.Concealer;
            RoleAlignment = RoleAlignment.SyndicateDisrup;
            ConcealMenu = new(Player, Click, Exception1);
            ConcealedPlayer = null;
            Type = LayerEnum.Concealer;
            ConcealButton = new(this, "Conceal", AbilityTypes.Effect, "Secondary", HitConceal);
            InspectorResults = InspectorResults.Unseen;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        public void Conceal()
        {
            Enabled = true;
            TimeRemaining -= Time.deltaTime;

            if (HoldsDrive)
                Utils.Conceal();
            else
                Utils.Invis(ConcealedPlayer, CustomPlayer.Local.Is(Faction.Syndicate));

            if (Utils.Meeting || (ConcealedPlayer == null && !HoldsDrive))
                TimeRemaining = 0f;
        }

        public void UnConceal()
        {
            Enabled = false;
            LastConcealed = DateTime.UtcNow;

            if (HoldsDrive)
                Utils.DefaultOutfitAll();
            else
                Utils.DefaultOutfit(ConcealedPlayer);

            ConcealedPlayer = null;
        }

        public float ConcealTimer()
        {
            var timespan = DateTime.UtcNow - LastConcealed;
            var num = Player.GetModifiedCooldown(CustomGameOptions.ConcealCooldown) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Click(PlayerControl player)
        {
            var interact = Utils.Interact(Player, player);

            if (interact[3])
                ConcealedPlayer = player;
            else if (interact[0])
                LastConcealed = DateTime.UtcNow;
            else if (interact[1])
                LastConcealed.AddSeconds(CustomGameOptions.ProtectKCReset);
        }

        public void HitConceal()
        {
            if (ConcealTimer() != 0f || Concealed)
                return;

            if (HoldsDrive)
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.Conceal);
                writer.Write(PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                TimeRemaining = CustomGameOptions.ConcealDuration;
                Conceal();
                Utils.Conceal();
            }
            else if (ConcealedPlayer == null)
                ConcealMenu.Open();
            else
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.Conceal);
                writer.Write(PlayerId);
                writer.Write(ConcealedPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                TimeRemaining = CustomGameOptions.ConcealDuration;
                Conceal();
                Utils.Invis(ConcealedPlayer, CustomPlayer.Local.Is(Faction.Syndicate));
            }
        }

        public bool Exception1(PlayerControl player) => player == ConcealedPlayer || player == Player || (player.Is(Faction) && !CustomGameOptions.ConcealMates);

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            var flag = ConcealedPlayer == null && !HoldsDrive;
            ConcealButton.Update(flag ? "SET TARGET" : "CONCEAL", ConcealTimer(), CustomGameOptions.ConcealCooldown, Concealed, TimeRemaining, CustomGameOptions.ConcealDuration);

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (ConcealedPlayer != null && !HoldsDrive && !Concealed)
                    ConcealedPlayer = null;

                Utils.LogSomething("Removed a target");
            }
        }
    }
}