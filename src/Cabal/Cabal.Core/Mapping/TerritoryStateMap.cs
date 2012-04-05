using Cabal.Core.Model;
using FluentNHibernate.Mapping;

namespace Cabal.Core.Mapping
{
    public class TerritoryStateMap : ClassMap<TerritoryState>
    {
        public TerritoryStateMap()
        {
            Id(x => x.Id);
            References(x => x.Game);
            
            Map(x => x.ControlledBy);
            Map(x => x.TerritoryId);

            HasMany(x => x.Armies)
                .AsMap(x => x.Nationality);
        }
    }
}
