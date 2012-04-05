using System.Collections.Generic;
using System.Linq;
using Cabal.Core.Config;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Services;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Services.GameServiceFixtures
{
    [TestFixture]
    public class GameServiceFixture : NHibernateSessionFixture
    {
        protected GameRepository GameRepository { get; private set;}
        protected PlayerRepository PlayerRepository { get; private set;}
        protected GameService ServiceUnderTest { get; private set; }

        
        protected Game ExpectedGame { get; private set;}

        protected const string OwnerName = "bob";

        protected override void Given()
        {
            base.Given();
            var settingsProvider = new StubCabalSettingsProvider(50);

            GameRepository = new GameRepository(NHibernateSession);
            PlayerRepository = new PlayerRepository(NHibernateSession, settingsProvider);

            ServiceUnderTest = new GameService(GameRepository, PlayerRepository);

            ExpectedGame = Build.Game();
            ExpectedGame.Owner.UserName = OwnerName;
            ExpectedGame.Start(ExpectedGame.Owner);
            GameRepository.Save(ExpectedGame);
            FlushSessionAndEvict(ExpectedGame);

        }
        [Test]
        public void Get_Active_Games()
        {
            

            IEnumerable<Game> activeGames = ServiceUnderTest.GetActiveGamesFor("bob");
            
        }
    }

    public class When_Getting_Active_Games : GameServiceFixture
    {
        protected IEnumerable<Game> activeGames;

        protected override void When()
        {
            base.When();
            activeGames = ServiceUnderTest.GetActiveGamesFor(OwnerName);
        }

        [Test]
        public void Includes_Games_With_The_Owner()
        {
            Assert.That(activeGames.Single().Id, Is.EqualTo(ExpectedGame.Id), "Didn't get the game we were looking for.");
        }
    }

    [TestFixture]
    public class When_Getting_All_Games : GameServiceFixture
    {
        protected IEnumerable<Game> allGames;

        protected override void When()
        {
            base.When();
            allGames = ServiceUnderTest.GetAllGamesFor(OwnerName);
        }

        [Test]
        public void Includes_Games_With_The_Owner()
        {
            Assert.That(allGames.Single().Id, Is.EqualTo(ExpectedGame.Id), "Didn't get the game we were looking for.");
        }
    }

    
}
