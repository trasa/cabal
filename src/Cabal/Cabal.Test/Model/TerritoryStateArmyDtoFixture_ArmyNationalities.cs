using System.Collections.Generic;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class TerritoryStateArmyDtoFixture_Nationality
    {

        private static void AssertNationality(Nationality expected, params Nationality[] nationalities)
        {
            var dto = new TerritoryStateDto();
            var armies = new List<TerritoryStateArmyDto>();
            foreach (var n in nationalities)
            {
                armies.Add(new TerritoryStateArmyDto {Nationality = n});
            }
            dto.Armies = armies.ToArray();
            Assert.That(dto.ArmyNationalities, Is.EqualTo(expected));
        }

        [Test]
        public void None()
        {
            AssertNationality(Nationality.None);
        }


        [Test]
        public void Germany()
        {
            AssertNationality(Nationality.Germany, Nationality.Germany);
        }

        [Test]
        public void Japan()
        {
            AssertNationality(Nationality.Japan, Nationality.Japan);
        }

        [Test]
        public void GermanyJapan()
        {
            AssertNationality(Nationality.Germany | Nationality.Japan, Nationality.Japan, Nationality.Germany);
            AssertNationality(Nationality.GermanyJapan, Nationality.Japan, Nationality.Germany);
        }

        [Test]
        public void SovietUnion()
        {
            AssertNationality(Nationality.SovietUnion, Nationality.SovietUnion);
        }

        [Test]
        public void UnitedKingdom()
        {
            AssertNationality(Nationality.UnitedKingdom, Nationality.UnitedKingdom);
        }

        [Test]
        public void UnitedStates()
        {
            AssertNationality(Nationality.UnitedStates, Nationality.UnitedStates);
        }

        [Test]
        public void SovietUnionUnitedKingdom()
        {
            AssertNationality(Nationality.SovietUnion | Nationality.UnitedKingdom, Nationality.SovietUnion, Nationality.UnitedKingdom);
            AssertNationality(Nationality.SovietUnionUnitedKingdom, Nationality.SovietUnion, Nationality.UnitedKingdom);
        }

        [Test]
        public void SovietUnionUnitedStates()
        {
            AssertNationality(Nationality.SovietUnion | Nationality.UnitedStates, Nationality.SovietUnion, Nationality.UnitedStates);
            AssertNationality(Nationality.SovietUnionUnitedStates, Nationality.SovietUnion, Nationality.UnitedStates);
        }

        [Test]
        public void SovietUnionUnitedStatesUnitedKingdom()
        {
            AssertNationality(Nationality.SovietUnion | Nationality.UnitedKingdom | Nationality.UnitedStates, Nationality.SovietUnion, Nationality.UnitedStates, Nationality.UnitedKingdom);
            AssertNationality(Nationality.SovietUnionUnitedKingdomUnitedStates, Nationality.SovietUnion, Nationality.UnitedStates, Nationality.UnitedKingdom);
        }

        [Test]
        public void UnitedKingdomUnitedStates()
        {
            AssertNationality(Nationality.UnitedKingdomUnitedStates, Nationality.UnitedStates, Nationality.UnitedKingdom);
        }
    }
}
