using Cabal.Core.Shared.Model;
using Cabal.Core.Model;
using FluentNHibernate.Testing;
using NUnit.Framework;

namespace Cabal.Test.MappingFixtures
{
    [TestFixture]
    public class TerritoryStateMapFixture : NHibernateSessionFixture
    {
        [Test]
        public void Verify()
        {
            new PersistenceSpecification<TerritoryState>(CurrentSession)
                .CheckProperty(x => x.TerritoryId, 51)
                .CheckProperty(x => x.ControlledBy, Nationality.Japan)
                .CheckReference(x => x.Game, new Game {Owner = new Player()})
                .VerifyTheMappings();
        }
    }
}