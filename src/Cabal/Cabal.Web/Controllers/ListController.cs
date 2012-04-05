using System.Security.Principal;
using System.Web.Mvc;
using Cabal.Core.Extensions;
using Cabal.Core.Services;

namespace Cabal.Web.Controllers
{
    [Authorize]
    public class ListController : ListControllerBase
    {
        private readonly IPrincipal user;

        public ListController(IPrincipal user, IGameService gameService) : base(gameService)
        {
            this.user = user;
        }



        public ActionResult Games(string list, string id)
        {
            if (string.IsNullOrEmpty(id))
                id = user.GetName();
            return View(GetGames(list, id));
        }

    }
}
