using TownOfUsReworked.Patches;
using TownOfUsReworked.Enums;
using TownOfUsReworked.Lobby.CustomOption;

namespace TownOfUsReworked.PlayerLayers.Modifiers.Modifiers
{
    public class Professional : Modifier
    {
        public bool LifeUsed = false;

        public Professional(PlayerControl player) : base(player)
        {
            Name = "Professional";
            TaskText = "You have an extra life when assassinating";
            Color = CustomGameOptions.CustomModifierColors ? Colors.Professional : Colors.Modifier;
            ModifierType = ModifierEnum.Professional;
            Hidden = !CustomGameOptions.ProfessionalKnows && !LifeUsed;
        }
    }
}