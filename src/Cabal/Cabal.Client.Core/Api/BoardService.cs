using Cabal.Client.Core.Model;
using Cabal.Core.Shared.Model;

namespace Cabal.Client.Core.Api
{
    public interface IBoardService
    {
        TerritoryStateDto[] GetBoardState();
        TerritoryStateDto GetTerritoryState(int territoryId);
    }

    public class BoardService : JsonService, IBoardService
    {
        private readonly SessionState sessionState;

        public BoardService(SessionState sessionState)
        {
            this.sessionState = sessionState;
        }

        public TerritoryStateDto[] GetBoardState()
        {
            var client = GetClient<TerritoryStateDto[]>("Board/GetBoardState");
            return client.Post(new GetBoardStateRequest(sessionState.AuthToken, sessionState.Game.Id));
        }

        public TerritoryStateDto GetTerritoryState(int territoryId)
        {
            var client = GetClient<TerritoryStateDto>("Board/GetTerritoryState");
            return client.Post(new GetTerritoryStateRequest(sessionState.AuthToken, sessionState.Game.Id, territoryId));
        }
    }
}
