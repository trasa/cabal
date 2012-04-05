using Blackfin.Core.NHibernate;
using Cabal.Core.Config;
using Cabal.Core.Model;
using NHibernate.Criterion;

namespace Cabal.Core.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetCpuPlayer();
        Player GetByName(string name);
    }

    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        private readonly ServerElement serverSettings;

        public PlayerRepository(NHibernateSession nhibernateSession, ICabalSettingsProvider settingsProvider) : base(nhibernateSession)
        {
            serverSettings = settingsProvider.CabalSection.Server;
        }

        public Player GetCpuPlayer()
        {
            return Session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("Id", serverSettings.CpuPlayerId))
                .UniqueResult<Player>();

        }

        public Player GetByName(string name)
        {
            return Session.CreateCriteria<Player>()
                .Add(Restrictions.Eq("UserName", name))
                .UniqueResult<Player>();
        }
    }
}
