using Cabal.Core.Model;

namespace Cabal.Core.Factories
{
    public interface IGameFactory
    {
        Game Create(Player creator, string description,
                    Player sovietPlayer, Player germanPlayer, Player britishPlayer,
                    Player japanesePlayer, Player americanPlayer);
    }

    public class GameFactory : IGameFactory
    {
        public Game Create(Player creator, string description,
            Player sovietPlayer, Player germanPlayer, Player britishPlayer, Player japanesePlayer, Player americanPlayer)
        {
            return new Game
                       {
                           Owner = creator,
                           CreatedBy = creator,
                           Description = description,
                           SovietPlayer = sovietPlayer,
                           GermanPlayer = germanPlayer,
                           BritishPlayer = britishPlayer,
                           JapanesePlayer = japanesePlayer,
                           AmericanPlayer = americanPlayer,
                       };
        }
    }
}
