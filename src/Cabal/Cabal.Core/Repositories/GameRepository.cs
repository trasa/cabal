using Blackfin.Core.NHibernate;
using Cabal.Core.Model;

namespace Cabal.Core.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        
    }

    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(NHibernateSession session)
            : base(session)
        {
        }

        public override Game Save(Game entity)
        {
            Game g = base.Save(entity);
            foreach(TerritoryState ts in g.TerritoryStates.Values)
            {
                // explicitly save these.
                Session.Save(ts);
                foreach(TerritoryStateArmy army in ts.Armies.Values)
                {
                    Session.Save(army);
                }
            }
            return g;
        }
    }
}
