using System;
using Blackfin.Core.NUnit;
using Cabal.Core.Model;
using Cabal.Core.Shared.Model;
using NUnit.Framework;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class TerritoryStateArmyFixture
    {
        [Test]
        public void Add_Units_To_Territory()
        {
            var t = new TerritoryStateArmy();
            t.AddUnits(MilitaryUnit.AircraftCarrier, 1);
            t.AddUnits(MilitaryUnit.Antiaircraft, 2);
            t.AddUnits(MilitaryUnit.Armor, 3);
            t.AddUnits(MilitaryUnit.Infantry, 4);
            t.AddUnits(MilitaryUnit.Battleship, 5);
            t.AddUnits(MilitaryUnit.Bomber, 6);
            t.AddUnits(MilitaryUnit.Fighter, 7);
            t.AddUnits(MilitaryUnit.IndustrialComplex, 1);
            t.AddUnits(MilitaryUnit.Submarine, 9);
            t.AddUnits(MilitaryUnit.Transport, 10);

            Assert.AreEqual(t.AircraftCarriers, 1);
            Assert.AreEqual(t.Antiaircraft, 2);
            Assert.AreEqual(t.Armor, 3);
            Assert.AreEqual(t.Infantry, 4);
            Assert.AreEqual(t.Battleships, 5);
            Assert.AreEqual(t.Bombers, 6);
            Assert.AreEqual(t.Fighters, 7);
            Assert.AreEqual(t.IndustrialComplexes, 1);
            Assert.AreEqual(t.Submarines, 9);
            Assert.AreEqual(t.Transports, 10);
        }

        [Test]
        public void Can_Have_Maximum_One_Complex_On_Territory()
        {
            var t = new TerritoryStateArmy { IndustrialComplexes = 0 };
            t.IndustrialComplexes = 1; // OK
            Expect.Exception<ArgumentOutOfRangeException>(() =>
            {
                t.IndustrialComplexes = 2; // NOT OK
            });
        }

        [Test]
        public void No_Negative_Units()
        {
            var t = new TerritoryStateArmy();
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.Armor = -1; });
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.AircraftCarriers = -1; });
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.Battleships = -1; });
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.Bombers = -1; });
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.Fighters = -1; });
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.Infantry = -1; });
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.IndustrialComplexes = -1; });
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.Submarines = -1; });
            Expect.Exception<ArgumentOutOfRangeException>(() => { t.Transports = -1; });
        }
    }
}
