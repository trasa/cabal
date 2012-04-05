using Cabal.Core.Model;
using FluentNHibernate.Mapping;

namespace Cabal.Core.Mapping
{
    public class TerritoryStateArmyMap : ClassMap<TerritoryStateArmy>
    {
        public TerritoryStateArmyMap()
        {
            Id(x => x.Id);
            References(x => x.TerritoryState).Cascade.All();
            
            Map(x => x.Nationality);
            
            Map(x => x.Armor);
            Map(x => x.Battleships);
            Map(x => x.Bombers);
            Map(x => x.Fighters);
            Map(x => x.Infantry);
            Map(x => x.IndustrialComplexes);
            Map(x => x.Antiaircraft);
            Map(x => x.Submarines);
            Map(x => x.Transports);
            Map(x => x.AircraftCarriers);
        }
    }
}
