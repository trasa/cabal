using System.Reflection;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Shared.Model;
using FluentNHibernate.Testing;
using log4net;
using NUnit.Framework;

namespace Cabal.Test.MappingFixtures
{
    [TestFixture]
    public class TerritoryStateArmyMapFixture : NHibernateSessionFixture
    {
        private static readonly ILog log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [Test]
        public void Verify()
        {
            var gameRepo = new GameRepository(NHibernateSession);
            var g = new Game {Owner = new Player()};
            gameRepo.Save(g);
            FlushSessionAndEvict(g);

            new PersistenceSpecification<TerritoryStateArmy>(CurrentSession)
                .CheckReference(x => x.TerritoryState, new TerritoryState {ControlledBy = Nationality.Germany, Game = g, TerritoryId = 50})
                .CheckProperty(x => x.Nationality, Nationality.Japan)

                .CheckProperty(x => x.Antiaircraft, 1)
                .CheckProperty(x => x.Armor, 2)
                .CheckProperty(x => x.Fighters, 3)
                .CheckProperty(x => x.Bombers, 4)
                .CheckProperty(x => x.Battleships, 5)
                .CheckProperty(x => x.Submarines, 6)
                .CheckProperty(x => x.Transports, 7)
                .CheckProperty(x => x.AircraftCarriers, 8)
                .CheckProperty(x => x.IndustrialComplexes, 1)
                .CheckProperty(x => x.Infantry, 10)
                .VerifyTheMappings();
        }
    }
}
