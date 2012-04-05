using System;
using Cabal.Core.Shared.Exceptions;
using Cabal.Core.Model;
using Cabal.Core.Shared.Model;

namespace Cabal.Core.Services
{
    public class GameStatusGenerator
    {
        private readonly Game game;

        public GameStatusGenerator(Game game)
        {
            this.game = game;
        }

        public override string ToString()
        {
            switch (game.GameState)
            {
                case GameState.AcceptingPlayers:
                    return "Not Started - Players Wanted";

                case GameState.StartPending:
                    return "Not Started - Start Pending";

                case GameState.PlayerTurn:
                    return game.CurrentNationality + "'s Turn [" + game.CurrentPlayer.UserName + "]";

                case GameState.GameOver:
                    //return "Game Over [Results here]";
                    throw new NotImplementedException();

                default:
                    throw new InvalidGameStateException("Unknown Game State: " + game.GameState);
            }
        }
    }
}
