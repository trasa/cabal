using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Blackfin.Core.Mvc.Controllers;
using Blackfin.Core.Mvc.Permit.Rules;
using Blackfin.Core.Permit.Rules;
using Cabal.Core.Helpers;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Rules;
using Cabal.Core.Shared.Model;

namespace Cabal.Web.Controllers
{
    public class BoardController : SmartController
    {
        private readonly IGameRepository gameRepository;

        public BoardController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [JsonFilter(Param = "request", RootType = typeof(GetBoardStateRequest), Order = 0)]
        [ValidateRule(typeof(AuthenticateToken), Order = 1)]
        // TODO [ValidateRule(typeof(PlayerBelongsToGame), Order = 2)]
        public JsonResult GetBoardState(
            [ExtractProperty(ParameterName="authToken", PropertyName="AuthToken")]GetBoardStateRequest request)
        {
            Game g = gameRepository.Get(request.GameId);
            if (g == null)
                return Json(new TerritoryStateDto[0]);
            return Json(g.TerritoryStateDtos);
        }

        [JsonFilter(Param="request", RootType=typeof(GetTerritoryStateRequest), Order = 0)]
        [ValidateRule(typeof(AuthenticateToken), Order = 1)]
        // TODO PlayerBelongsToGame Rule
        public JsonResult GetTerritoryState(
            [ExtractProperty(ParameterName="authToken", PropertyName="AuthToken")]GetTerritoryStateRequest request)
        {
            Game g = gameRepository.Get(request.GameId);
            if (g == null)
                return Json(new TerritoryStateDto());
            return Json(g.GetTerritory(request.TerritoryId).ToDto());
        }
    }
}
