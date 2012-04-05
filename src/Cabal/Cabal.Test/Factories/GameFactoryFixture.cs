using Cabal.Core.Factories;
using Cabal.Core.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Factories
{
    [TestFixture]
    public class GameFactoryFixture
    {
        [Test]
        public void New_Games_Have_A_Creator()
        {
            var creator = new Player();
            Game g = factory.Create(creator, "description", null, null, null, null, null);
            Assert.That(g.CreatedBy, Is.EqualTo(creator));
        }

        [Test]
        public void New_Games_Have_An_Owner()
        {
            var creator = new Player();
            Game g = factory.Create(creator, "description", null, null, null, null, null);
            Assert.That(g.Owner, Is.EqualTo(creator));
        }

        [Test]
        public void New_Games_Have_Players()
        {
            var soviet = new Player();
            var german = new Player();
            var uk = new Player();
            var japanese = new Player();
            var usa = new Player();

            Game g = factory.Create(soviet, "hi", soviet, german, uk, japanese, usa);
            Assert.That(g.SovietPlayer, Is.SameAs(soviet));
            Assert.That(g.GermanPlayer, Is.SameAs(german));
            Assert.That(g.BritishPlayer, Is.SameAs(uk));
            Assert.That(g.JapanesePlayer, Is.SameAs(japanese));
            Assert.That(g.AmericanPlayer, Is.SameAs(usa));
        }

        private GameFactory factory;
        [SetUp]
        public void SetUp()
        {
            factory = new GameFactory();
        }


    }
}
