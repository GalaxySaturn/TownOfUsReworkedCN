namespace TownOfUsReworked.PlayerLayers.Abilities
{
    public class Ninja : Ability
    {
        public Ninja(PlayerControl player) : base(player)
        {
            Name = "Ninja";
            TaskText = () => "- You do not lunge";
            Color = CustomGameOptions.CustomAbilityColors ? Colors.Ninja : Colors.Ability;
            AbilityType = AbilityEnum.Ninja;
            Type = LayerEnum.Ninja;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }
    }
}