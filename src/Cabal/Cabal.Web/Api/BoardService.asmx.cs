using System.Linq;
using System.Security.Principal;
using System.Web.Services;
using Blackfin.Core.Permit.Rules;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Rules;
using Cabal.Core.Services;
using Cabal.Core.Shared.Model;

namespace Cabal.Web.Api
{
    [WebService(Namespace = "http://meancat.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class BoardService : InjectableWebService
    {
        public IGameService GameService { get; set;}
        public IGameRepository GameRepository { get; set; }
        public IPlayerService PlayerService { get; set; }


        [WebMethod]
        public string Login(string username, string password)
        {
            CabalAuthenticationTicket ticket = PlayerService.Authenticate(username, password);
            if (ticket == null)
                return null;
            return ticket.Encrypt();
        }


        [WebMethod]
        public TerritoryStateDto[] GetBoardState(string authToken, int gameId)
        {
            Authenticate(authToken);
            Verify.Rule<PlayerBelongsToGame>(Context.User, new {gameId});
            
            Game g = GameRepository.Get(gameId);
            if (g == null)
                return new TerritoryStateDto[0];
            return g.TerritoryStateDtos.ToArray();
        }

        [WebMethod]
        public TerritoryStateDto GetTerritoryState(string authToken, int gameId, int territoryId)
        {
            Authenticate(authToken);
            Verify.Rule<PlayerBelongsToGame>(Context.User, new { gameId });

            GameRepository.Get(gameId);
            Game g = GameRepository.Get(gameId);
            if (g == null)
                return null;
            return g.GetTerritory(territoryId).ToDto();
        }

        [WebMethod]
        public GameDto[] GetActiveGames(string username)
        {
            return (from g in GameService.GetActiveGamesFor(username)
                   select g.ToDto())
                   .ToArray();

        }
    }
}
