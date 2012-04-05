using Cabal.Core.Model;
using Cabal.Core.Services;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Services
{
    [TestFixture]
    public class GameStatusGeneratorFixture
    {
        [Test]
        public void When_Game_Hasnt_Started_Yet()
        {
            var status = new GameStatusGenerator(new Game());
            Assert.That(status.ToString(), Is.EqualTo("Not Started - Players Wanted"));
        }

        [Test]
        public void When_Game_Is_Pending_Start()
        {
            var status = new GameStatusGenerator(Build.Game());
            Assert.That(status.ToString(), Is.EqualTo("Not Started - Start Pending"));
        }

        [Test, Ignore("GameOver condition not defined yet")]
        public void When_Game_Is_Over()
        {
            // when the game is in GameState.GameOver?
            Assert.Fail("GameOver condition not defined yet");
        }

        [Test]
        public void When_Its_Player_Turn()
        {
            // Gamestate.PlayerTurn
            var game = Build.Game();
            game.Start(game.Owner);
            
            var status = new GameStatusGenerator(game);
            Assert.That(status.ToString(), Is.EqualTo(
                "SovietUnion's Turn [" + game.CurrentPlayer.UserName + "]"));
        }
    }
}
