namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Godfather : Intruder
    {
        public bool HasDeclared;
        public CustomButton DeclareButton;
        public DateTime LastDeclared;

        public Godfather(PlayerControl player) : base(player)
        {
            Name = "Godfather";
            RoleType = RoleEnum.Godfather;
            StartText = () => "Promote Your Fellow <color=#FF0000FF>Intruder</color> To Do Better";
            AbilitiesText = () => "- You can promote a fellow <color=#FF0000FF>Intruder</color> into becoming your successor\n- Promoting an <color=#FF0000FF>Intruder</color> turns them " +
                "into a <color=#6400FFFF>Mafioso</color>\n- If you die, the <color=#6400FFFF>Mafioso</color> will become the new <color=#404C08FF>Godfather</color>\nand inherits better " +
                $"abilities of their former role\n{CommonAbilities}";
            Color = CustomGameOptions.CustomIntColors ? Colors.Godfather : Colors.Intruder;
            RoleAlignment = RoleAlignment.IntruderSupport;
            Type = LayerEnum.Godfather;
            DeclareButton = new(this, "Promote", AbilityTypes.Direct, "Secondary", Declare);
            InspectorResults = InspectorResults.LeadsTheGroup;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }

        public static void Declare(Godfather gf, PlayerControl target)
        {
            gf.HasDeclared = true;
            var formerRole = GetRole(target);

            var mafioso = new Mafioso(target)
            {
                FormerRole = formerRole,
                Godfather = gf
            };

            mafioso.RoleUpdate(formerRole);

            if (target == CustomPlayer.Local)
                Utils.Flash(Colors.Mafioso);

            if (CustomPlayer.Local.Is(RoleEnum.Seer))
                Utils.Flash(Colors.Seer);
        }

        public void Declare()
        {
            if (Utils.IsTooFar(Player, DeclareButton.TargetPlayer) || HasDeclared)
                return;

            var interact = Utils.Interact(Player, DeclareButton.TargetPlayer);

            if (interact[3])
            {
                var writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.Action, SendOption.Reliable);
                writer.Write((byte)ActionsRPC.Declare);
                writer.Write(PlayerId);
                writer.Write(DeclareButton.TargetPlayer.PlayerId);
                AmongUsClient.Instance.FinishRpcImmediately(writer);
                Declare(this, DeclareButton.TargetPlayer);
            }
            else if (interact[0])
                LastDeclared = DateTime.UtcNow;
            else if (interact[1])
                LastDeclared.AddSeconds(CustomGameOptions.ProtectKCReset);
        }

        public bool Exception1(PlayerControl player) => !player.Is(Faction) || (!(player.GetRole() is RoleEnum.PromotedGodfather or RoleEnum.Mafioso or RoleEnum.Godfather) &&
            player.Is(Faction));

        public override void UpdateHud(HudManager __instance)
        {
            base.UpdateHud(__instance);
            DeclareButton.Update("PROMOTE", true, !HasDeclared);
        }
    }
}