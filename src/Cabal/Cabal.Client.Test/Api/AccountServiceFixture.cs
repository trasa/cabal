using System;
using Cabal.Client.Core.Api;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Client.Test.Api
{
    [TestFixture]
    public class AccountServiceFixture
    {
        private AccountService service;
        [SetUp]
        public void SetUp()
        {
            service = new AccountService();
        }
		
        [Test]
        public void Login()
        {
            string ticket = service.Login("admin", "admin");
            Console.WriteLine(ticket);
            Assert.That(ticket, Is.Not.Null);
        }

        [Test]
        public void GetGames()
        {
            GameDto[] games = service.GetActiveGames("admin");
            Assert.That(games, Is.Not.Null);
            Assert.That(games.Length, Is.Not.EqualTo(0));
        }
    }
}
