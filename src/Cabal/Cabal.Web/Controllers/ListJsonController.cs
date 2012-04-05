using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cabal.Core.Services;

namespace Cabal.Web.Controllers
{
    public class ListJsonController : ListControllerBase
    {
        public ListJsonController(IGameService gameService) : base(gameService)
        {
        }

        public JsonResult Games(string list, string id)
        {
            return Json(GetGames(list, id)
                            .Select(g => g.ToDto())
                            .ToArray());
        }
    }
}
