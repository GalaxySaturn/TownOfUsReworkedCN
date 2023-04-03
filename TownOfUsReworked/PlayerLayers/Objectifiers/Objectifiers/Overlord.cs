using TownOfUsReworked.CustomOptions;
using TownOfUsReworked.Data;

namespace TownOfUsReworked.PlayerLayers.Objectifiers
{
    public class Overlord : Objectifier
    {
        public bool IsAlive => !(Player.Data.IsDead || Player.Data.Disconnected);

        public Overlord(PlayerControl player) : base(player)
        {
            Name = "Overlord";
            SymbolName = "β";
            TaskText = $"- Stay alive for {CustomGameOptions.OverlordMeetingWinCount} meetings.";
            Color = CustomGameOptions.CustomObjectifierColors ? Colors.Overlord : Colors.Objectifier;
            Type = ObjectifierEnum.Overlord;
            Hidden = !CustomGameOptions.OverlordKnows;
        }
    }
}