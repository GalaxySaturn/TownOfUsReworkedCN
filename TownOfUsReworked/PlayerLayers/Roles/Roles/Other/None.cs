namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Roleless : Role
    {
        public Roleless(PlayerControl player) : base(player) => Name = "None";
    }
}