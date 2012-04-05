using System;
using System.Security.Principal;
using Cabal.Core.Extensions;
using Cabal.Core.Model;

namespace Cabal.Core.Services
{
    public interface ICurrentPlayerProvider
    {
        Player GetUserPlayer();
    }
    public class CurrentPlayerProvider : ICurrentPlayerProvider
    {
        private readonly IPrincipal user;

        public CurrentPlayerProvider(IPrincipal user)
        {
            this.user = user;
        }

        public Player GetUserPlayer()
        {
            return user.GetPlayer();
        }
    }

    public class StubCurrentPlayerProvider : ICurrentPlayerProvider
    {
        private readonly Player player;

        public StubCurrentPlayerProvider(Player player)
        {
            this.player = player;
        }

        public Player GetUserPlayer()
        {
            return player;
        }
    }
}
