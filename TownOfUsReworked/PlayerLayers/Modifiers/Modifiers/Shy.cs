namespace TownOfUsReworked.PlayerLayers.Modifiers
{
    public class Shy : Modifier
    {
        public Shy(PlayerControl player) : base(player)
        {
            Name = "Shy";
            TaskText = () => "- You cannot call meetings";
            Color = CustomGameOptions.CustomModifierColors ? Colors.Shy : Colors.Modifier;
            ModifierType = ModifierEnum.Shy;
            Type = LayerEnum.Shy;

            if (TownOfUsReworked.IsTest)
                Utils.LogSomething($"{Player.name} is {Name}");
        }
    }
}