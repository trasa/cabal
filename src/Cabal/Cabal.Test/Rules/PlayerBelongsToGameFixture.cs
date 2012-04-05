using System.Security.Principal;
using Blackfin.Core.NUnit;
using Blackfin.Core.Permit.Rules;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Rules;
using Moq;
using NUnit.Framework;
using StructureMap;

namespace Cabal.Test.Rules
{
    [TestFixture]
    public class PlayerBelongsToGameFixture
    {
        private Mock<IPlayerRepository> playerRepository;
        private PlayerBelongsToGame rule;

        [SetUp]
        public void SetUp()
        {
            playerRepository = new Mock<IPlayerRepository>();
            var gameRepository = new Mock<IGameRepository>();
            
            var player = new Player();
            var game = new Game { Id = 1, SovietPlayer = player };
            
            playerRepository.Setup(repo => repo.GetByName("player")).Returns(player);
            playerRepository.Setup(repo => repo.GetByName("SomeOtherGuy")).Returns(new Player());
            gameRepository.Setup(repo => repo.Get(1)).Returns(game);

            ObjectFactory.Configure(c => c.ForRequestedType<IPlayerRepository>().TheDefault.IsThis(playerRepository.Object));
            rule = new PlayerBelongsToGame(gameRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            ObjectFactory.ResetDefaults();
        }
		

        [Test]
        public void Player_Must_Be_Part_Of_A_Game()
        {
            var user = new GenericPrincipal(new GenericIdentity("player"), new string[0]);
            var context = new RuleContext(user, new {gameId = 1});
            rule.Validate(context);
        }

        [Test]
        public void Player_Not_In_Game_Gets_Exception()
        {
            var someOtherGuy = new GenericPrincipal(new GenericIdentity("SomeOtherGuy"), new string[0]);
            var context = new RuleContext(someOtherGuy, new { gameId = 1 });
            Expect.Exception<RuleException>(() => rule.Validate(context));
        }
    }
}
