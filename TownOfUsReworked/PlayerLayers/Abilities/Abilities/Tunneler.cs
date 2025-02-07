namespace TownOfUsReworked.PlayerLayers.Abilities
{
    public class Tunneler : Ability
    {
        public Tunneler(PlayerControl player) : base(player)
        {
            Name = "Tunneler";
            TaskText = () => "- You can finish tasks to be able to vent";
            Color = CustomGameOptions.CustomAbilityColors ? Colors.Tunneler : Colors.Ability;
            AbilityType = AbilityEnum.Tunneler;
            Hidden = !CustomGameOptions.TunnelerKnows && !TasksDone;
            Type = LayerEnum.Tunneler;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }
    }
}