using System.Collections.Generic;
using System.Security.Principal;
using System.Web.Mvc;
using Blackfin.Core.Mvc.Controllers;
using Cabal.Core.Extensions;
using Cabal.Core.Model;
using Cabal.Core.Services;

namespace Cabal.Web.Controllers
{
    [Authorize]
    public class PlayerController : SmartController
    {
        private readonly IPrincipal user;
        private readonly IGameService gameService;

        public PlayerController(IPrincipal user, IGameService gameService)
        {
            this.user = user;
            this.gameService = gameService;
        }

        public ActionResult Index()
        {
            Player player = user.GetPlayer();
            var vm = new PlayerIndexViewModel
                         {
                             Player = player,
                             Games = gameService.GetAllGamesFor(player)
                         };
            return View(vm);
        }   
    }

    public class PlayerIndexViewModel
    {
        public Player Player { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}
