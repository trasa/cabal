using System.Collections.Generic;
using System.Linq;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Shared.Model;
using NHibernate.Criterion;

namespace Cabal.Core.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetActiveGamesFor(string userName);
        IEnumerable<Game> GetAllGamesFor(string userName);

        IEnumerable<Game> GetActiveGamesFor(Player player);
        IEnumerable<Game> GetAllGamesFor(Player player);

    }

    public class GameService : IGameService
    {
        private readonly IRepository<Game> gameRepository;
        private readonly IPlayerRepository playerRepository;

        public GameService(IRepository<Game> gameRepository, IPlayerRepository playerRepository)
        {
            this.gameRepository = gameRepository;
            this.playerRepository = playerRepository;
        }



        public IEnumerable<Game> GetActiveGamesFor(string playerName)
        {
            IEnumerable<Game> gamesForPlayer = GetAllGamesFor(playerName);
            return from g in gamesForPlayer
                   where g.IsStarted && g.GameState != GameState.GameOver
                   select g;
        }

        public IEnumerable<Game> GetAllGamesFor(string playerName)
        {
            DetachedCriteria query = BuildAllGamesCriteria(playerName);
            if (query == null)
                return new List<Game>();
            return gameRepository.QueryList(query);
        }

        public IEnumerable<Game> GetActiveGamesFor(Player player)
        {
            return GetActiveGamesFor(player.UserName);
        }

        public IEnumerable<Game> GetAllGamesFor(Player player)
        {
            return GetAllGamesFor(player.UserName);
        }

        private DetachedCriteria BuildAllGamesCriteria(string playerName)
        {
            Player player = playerRepository.GetByName(playerName);
            if (player == null)
                return null;
            return DetachedCriteria.For<Game>()
                .Add(
                Expression.Or(Expression.Eq("Owner", player),
                              Expression.Or(Expression.Eq("SovietPlayer", player),
                                            Expression.Or(Expression.Eq("GermanPlayer", player),
                                                          Expression.Or(Expression.Eq("BritishPlayer", player),
                                                                        Expression.Or(
                                                                            Expression.Eq("JapanesePlayer", player),
                                                                            Expression.Eq("AmericanPlayer", player)))))));
        }
    }
}