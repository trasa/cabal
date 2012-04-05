using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blackfin.Core.Mvc.Controllers;
using Cabal.Core.Model;
using Cabal.Core.Services;

namespace Cabal.Web.Controllers
{
    public abstract class ListControllerBase : SmartController
    {
        private readonly IGameService gameService;

        protected ListControllerBase(IGameService gameService)
        {
            this.gameService = gameService;
        }


        protected IEnumerable<Game> GetGames(string list, string id)
        {
            if (list.Equals("active", StringComparison.InvariantCultureIgnoreCase))
                return gameService.GetActiveGamesFor(id);

            return gameService.GetAllGamesFor(id);
        }
    }
}
