namespace TownOfUsReworked.PlayerLayers.Abilities
{
    public class Multitasker : Ability
    {
        public Multitasker(PlayerControl player) : base(player)
        {
            Name = "Multitasker";
            TaskText = () => "- Your task windows are transparent";
            Color = CustomGameOptions.CustomAbilityColors ? Colors.Multitasker : Colors.Ability;
            AbilityType = AbilityEnum.Multitasker;
            Type = LayerEnum.Multitasker;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }
    }
}