namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Spellslinger : Syndicate
    {
        public CustomButton SpellButton;
        public List<byte> Spelled = new();
        public DateTime LastSpelled;
        public int SpellCount;

        public Spellslinger(PlayerControl player) : base(player)
        {
            Name = "Spellslinger";
            StartText = () => "Place the <color=#8CFFFFFF>Crew</color> Under A Curse";
            AbilitiesText = () => "- You can place a spell on players\n- When all non-<color=#008000FF>Syndicate</color> players are spelled the game ends in a <color=#008000FF>Syndicate" +
                $"</color> win\n- With the Chaos Drive, your spells are astral\n{CommonAbilities}";
            RoleType = RoleEnum.Spellslinger;
            RoleAlignment = RoleAlignment.SyndicatePower;
            Color = CustomGameOptions.CustomSynColors ? Colors.Spellslinger : Colors.Syndicate;
            Spelled = new();
            SpellCount = 0;
            Type = LayerEnum.Spellslinger;
            SpellButton = new(this, "Spell", AbilityTypes.Direct, "Secondary", HitSpell, Exception1);
            InspectorResults = InspectorResults.SeeksToDestroy;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        public float SpellTimer()
        {
            var timespan = DateTime.UtcNow - LastSpelled;
            var num = Player.GetModifiedCooldown(CustomGameOptions.SpellCooldown, SpellCount * CustomGameOptions.SpellCooldownIncrease) * 1000f;
            var flag2 = num - (float)timespan.TotalMilliseconds < 0f;
            return flag2 ? 0f : (num - (float)timespan.TotalMilliseconds) / 1000f;
        }

        public void Spell(PlayerControl player)
        {
            if (player.Is(Faction) || Spelled.Contains(player.PlayerId))
                return;

            Spelled.Add(player.PlayerId);
            var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
            writer.Write((byte)ActionsRPC.Spell);
            writer.Write(PlayerId);
            writer.Write(player.PlayerId);
            AmongUsClient.Instance.FinishRpcImmediately(writer);

            if (!HoldsDrive)
                SpellCount++;
        }

        public void HitSpell()
        {
            if (SpellTimer() != 0f || Utils.IsTooFar(Player, SpellButton.TargetPlayer))
                return;

            if (HoldsDrive)
            {
                Spell(SpellButton.TargetPlayer);
                LastSpelled = DateTime.UtcNow;
            }
            else
            {
                var interact = Utils.Interact(Player, SpellButton.TargetPlayer);

                if (interact[3])
                    Spell(SpellButton.TargetPlayer);

                if (interact[0])
                    LastSpelled = DateTime.UtcNow;
                else if (interact[1])
                    LastSpelled.AddSeconds(CustomGameOptions.ProtectKCReset);
            }
        }

        public bool Exception1(PlayerControl player) => Spelled.Contains(player.PlayerId) || player.Is(Faction);

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            SpellButton.Update("SPELL", SpellTimer(), CustomGameOptions.SpellCooldown + (SpellCount * CustomGameOptions.SpellCooldownIncrease));
        }
    }
}