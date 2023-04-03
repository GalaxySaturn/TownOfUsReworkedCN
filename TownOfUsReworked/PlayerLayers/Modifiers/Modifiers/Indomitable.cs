using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Modifiers
{
    public class Indomitable : Modifier
    {
        public Indomitable(PlayerControl player) : base(player)
        {
            Name = "Indomitable";
            TaskText = "- You cannot be guessed.";
            Color = CustomGameOptions.CustomModifierColors ? Colors.Indomitable : Colors.Modifier;
            Type = ModifierEnum.Indomitable;
            Hidden = !CustomGameOptions.IndomitableKnows;
        }
    }
}