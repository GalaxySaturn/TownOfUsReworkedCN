using UnityEngine;
using TownOfUsReworked.Classes;
using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Modules;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Modifiers
{
    public class Giant : Modifier, IVisualAlteration
    {
        public Giant(PlayerControl player) : base(player)
        {
            var slowText = CustomGameOptions.GiantSpeed != 1 ? " and slow" : "";
            Name = "Giant";
            TaskText = $"- You are ginormous{slowText}.";
            Color = CustomGameOptions.CustomModifierColors ? Colors.Giant : Colors.Modifier;
            Type = ModifierEnum.Giant;
        }

        public bool TryGetModifiedAppearance(out VisualAppearance appearance)
        {
            appearance = Player.GetDefaultAppearance();
            appearance.SpeedFactor = (Player.Data.IsDead ? CustomGameOptions.GhostSpeed : CustomGameOptions.PlayerSpeed) * CustomGameOptions.GiantSpeed;
            appearance.SizeFactor = new Vector3(CustomGameOptions.GiantScale, CustomGameOptions.GiantScale, 1f);
            return true;
        }
    }
}