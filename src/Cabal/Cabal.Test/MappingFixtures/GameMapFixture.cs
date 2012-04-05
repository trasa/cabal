using Cabal.Core.Model;
using Cabal.Core.Shared.Model;
using Cabal.Core.Repositories;
using FluentNHibernate.Testing;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.MappingFixtures
{
    [TestFixture]
    public class GameMapFixture : NHibernateSessionFixture
    {
        [Test]
        public void Verify()
        {
            new PersistenceSpecification<Game>(CurrentSession)
                .CheckProperty(x => x.Description, "foo")
                .CheckProperty(x => x.IsStarted, true)
                .CheckProperty(x => x.CurrentNationality, Nationality.Japan)
                .CheckReference(x => x.Owner, new Player())
                .CheckReference(x => x.CreatedBy, new Player())
                .CheckReference(x => x.SovietPlayer, new Player())
                .CheckReference(x => x.GermanPlayer, new Player())
                .CheckReference(x => x.BritishPlayer, new Player())
                .CheckReference(x => x.JapanesePlayer, new Player())
                .CheckReference(x => x.AmericanPlayer, new Player())
                .CheckProperty(x => x.AmericanIpcAmount, 32)
                .CheckProperty(x => x.SovietIpcAmount, 15)
                .CheckProperty(x => x.BritishIpcAmount, 12)
                .CheckProperty(x => x.JapaneseIpcAmount, 90)
                .CheckProperty(x => x.GermanIpcAmount, 105)
                .CheckProperty(x => x.AmericanIncome, 10)
                .CheckProperty(x => x.SovietIncome, 15)
                .CheckProperty(x => x.BritishIncome, 16)
                .CheckProperty(x => x.GermanIncome, 30)
                .CheckProperty(x => x.JapaneseIncome, 29)

                .VerifyTheMappings();
        }

        [Test]
        public void Games_Have_Territories()
        {
            var gameRepo = new GameRepository(NHibernateSession);
            var owner = new Player();
            var g = new Game
                         {
                             Owner = owner
                         };
            var t = g.GetTerritory(Territory.WesternUsa);
            t.ControlledBy = Nationality.UnitedStates;
            t.AddUnits(Nationality.UnitedStates, MilitaryUnit.Infantry, 5);

            gameRepo.Save(g);
            FlushSessionAndEvict(g);
            Assert.That(g.Id, Is.Not.EqualTo(0));

            var g2 = gameRepo.Get(g.Id);
            Assert.That(g2.TerritoryStates, Is.Not.Empty);
            var t2 = g.GetTerritory(Territory.WesternUsa);
            var army = t2.Armies[Nationality.UnitedStates];
            Assert.That(army.Infantry, Is.EqualTo(5));
            Assert.That(t2.ControlledBy, Is.EqualTo(Nationality.UnitedStates));
            Assert.That(army.Nationality, Is.EqualTo(Nationality.UnitedStates));
        }

        [Test]
        public void Games_Have_Territories_That_Can_Be_Updated()
        {
            var gameRepo = new GameRepository(NHibernateSession);
            var g = new Game
                        {
                            Owner = new Player(),
                        };
            var t = g.GetTerritory(Territory.WesternUsa);
            t.ControlledBy = Nationality.UnitedStates;
            t.AddUnits(Nationality.UnitedStates, MilitaryUnit.Infantry, 5);

            gameRepo.Save(g);
            FlushSessionAndEvict(g);
            

            var g2 = gameRepo.Get(g.Id);
            Assert.That(g2.TerritoryStates.Count, Is.EqualTo(1));
            var t2 = g.GetTerritory(Territory.WesternUsa);
            var army = t2.Armies[Nationality.UnitedStates];
            army.Infantry = 7;
            gameRepo.Save(g2);
            FlushSessionAndEvict(g2);

            var g3 = gameRepo.Get(g.Id);
            Assert.That(g3.TerritoryStates.Count, Is.EqualTo(1));
            var t3 = g.GetTerritory(Territory.WesternUsa);
            var army3 = t3.Armies[Nationality.UnitedStates];
            Assert.That(army3.Infantry, Is.EqualTo(7));
            Assert.That(army3.Nationality,Is.EqualTo(Nationality.UnitedStates));
            Assert.That(t3.ControlledBy, Is.EqualTo(Nationality.UnitedStates));
        }
    }
}
