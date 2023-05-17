namespace TownOfUsReworked.PlayerLayers.Roles
{
    public class Anarchist : SyndicateRole
    {
        public Anarchist(PlayerControl player) : base(player)
        {
            Name = "Anarchist";
            RoleType = RoleEnum.Anarchist;
            StartText = "Wreck Everyone With A Passion";
            RoleAlignment = RoleAlignment.SyndicateUtil;
            Base = true;
            Type = LayerEnum.Anarchist;
            InspectorResults = InspectorResults.IsBasic;
        }
    }
}