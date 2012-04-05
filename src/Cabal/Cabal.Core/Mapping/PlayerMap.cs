using Cabal.Core.Model;
using FluentNHibernate.Mapping;

namespace Cabal.Core.Mapping
{
    public class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Id(x => x.Id);
            Map(x => x.UserName);
        }
    }
}
