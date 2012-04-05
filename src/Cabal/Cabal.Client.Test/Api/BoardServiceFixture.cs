using Cabal.Client.Core.Api;
using Cabal.Client.Core.Model;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Client.Test.Api
{
    [TestFixture]
    public class BoardServiceFixture
    {
        private BoardService service;
        private SessionState sessionState;

        [SetUp]
        public void SetUp()
        {
            var acctService = new AccountService();
            sessionState = new SessionState
                               {
                                   AuthToken = acctService.Login("admin", "admin"),
                                   Game = new GameDto{Id=1},
                               };
            Assert.That(!string.IsNullOrEmpty(sessionState.AuthToken), "Hey WTF - login failed.");
            service = new BoardService(sessionState);
        }

       

        [Test]
        public void GetBoardState()
        {
            TerritoryStateDto[] states = service.GetBoardState();
            Assert.That(states, Is.Not.Null);
            Assert.That(states.Length, Is.Not.EqualTo(0));
        }

        [Test]
        public void GetTerritoryState()
        {
            TerritoryStateDto state = service.GetTerritoryState(Territory.WesternUsa.Id);
            Assert.That(state, Is.Not.Null);
        }
    }

    
    [TestFixture]
    public class BoardServiceFixture_Bad_Ticket
    {
        private BoardService service;

        [SetUp]
        public void SetUp()
        {
            service = new BoardService(new SessionState
                                           {
                                               AuthToken = "aslkdjfjlsadfj",
                                               Game = new GameDto { Id = 1},
                                           });
        }

        [Test]
        public void Bad_Ticket_Fails()
        {
            Assert.That(service.GetBoardState(), Is.Null);
        }
    }
}
