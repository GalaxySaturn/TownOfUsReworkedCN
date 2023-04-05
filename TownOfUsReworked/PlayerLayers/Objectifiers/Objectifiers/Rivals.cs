using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Objectifiers
{
    public class Rivals : Objectifier
    {
        public PlayerControl OtherRival;

        public Rivals(PlayerControl player) : base(player)
        {
            Name = "Rival";
            SymbolName = "α";
            TaskText = "- Get your rival killed and then live to the final 2.";
            Color = CustomGameOptions.CustomObjectifierColors ? Colors.Rivals : Colors.Objectifier;
            ObjectifierType = ObjectifierEnum.Rivals;
        }

        public bool RivalDead() => OtherRival?.Data?.IsDead == true || OtherRival?.Data?.Disconnected == true;

        public bool IsDeadRival() => Player?.Data?.IsDead == true || Player?.Data?.Disconnected == true;

        public bool BothRivalsDead() => IsDeadRival() && RivalDead();

        public bool IsWinningRival() =>  RivalDead() && !IsDeadRival();
    }
}