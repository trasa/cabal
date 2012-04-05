using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class TerritoryAdjacencyFixture 
    {
        [Test]
        public void Europe()
        {
            Assert.That(Territory.Germany.IsAdjacentTo(Territory.WesternEurope));
            Assert.That(Territory.Germany.IsAdjacentTo(Territory.Switzerland));
            Assert.That(Territory.Germany.IsAdjacentTo(Territory.SouthernEurope));
            Assert.That(Territory.Germany.IsAdjacentTo(Territory.BalticSea));
            Assert.That(Territory.Germany.IsAdjacentTo(Territory.EasternEurope));
            
            Assert.That(Territory.EnglishChannel.IsAdjacentTo(Territory.UnitedKingdom));
            Assert.That(Territory.EnglishChannel.IsAdjacentTo(Territory.Eire));
            Assert.That(Territory.EnglishChannel.IsAdjacentTo(Territory.BarentsSea));
            
            Assert.That(Territory.Gibraltar.IsAdjacentTo(Territory.GibraltarMediterraneanSea));
            Assert.That(Territory.GibraltarMediterraneanSea.IsAdjacentTo(Territory.MediterraneanSea));
            Assert.That(Territory.BlackSea.IsAdjacentTo(Territory.MediterraneanSea));

            Assert.That(Territory.EasternEurope.IsAdjacentTo(Territory.BalticSea));

            // is NOT adjacent
            Assert.That(Territory.FinlandNorway.IsAdjacentTo(Territory.BarentsSea), Is.False); 
            Assert.That(Territory.Germany.IsAdjacentTo(Territory.UnitedKingdom), Is.False);
        }

        [Test]
        public void Atlantic()
        {
            Assert.That(Territory.EasternCanadaSea.IsAdjacentTo(Territory.EasternCanada));
            Assert.That(Territory.EasternCanadaSea.IsAdjacentTo(Territory.EnglishChannel));
            Assert.That(Territory.EasternCanadaSea.IsAdjacentTo(Territory.SpanishAtlantic));
            Assert.That(Territory.EasternCanadaSea.IsAdjacentTo(Territory.EasternUsaSea));
            Assert.That(Territory.EasternCanadaSea.IsAdjacentTo(Territory.AtlanticOcean));
            
            Assert.That(Territory.SpanishAtlantic.IsAdjacentTo(Territory.EnglishChannel));
            Assert.That(Territory.SpanishAtlantic.IsAdjacentTo(Territory.EasternCanadaSea));
            Assert.That(Territory.SpanishAtlantic.IsAdjacentTo(Territory.AtlanticOcean));
            Assert.That(Territory.SpanishAtlantic.IsAdjacentTo(Territory.GibraltarMediterraneanSea));
            Assert.That(Territory.SpanishAtlantic.IsAdjacentTo(Territory.FrenchWestAfricaSea));

            Assert.That(Territory.AtlanticOcean.IsAdjacentTo(Territory.NorthBrazilSea));
            Assert.That(Territory.AtlanticOcean.IsAdjacentTo(Territory.CaribbeanSea));
            Assert.That(Territory.AtlanticOcean.IsAdjacentTo(Territory.FrenchWestAfricaSea));
        }

        [Test]
        public void Africa()
        {
            Assert.That(Territory.RedSea.IsAdjacentTo(Territory.SaudiArabia));
            Assert.That(Territory.RedSea.IsAdjacentTo(Territory.EastMediterraneanSea));
            Assert.That(Territory.RedSea.IsAdjacentTo(Territory.IndianOcean));

            Assert.That(Territory.BelgianCongo.IsAdjacentTo(Territory.BelgianCongoSea));
            Assert.That(Territory.BelgianCongo.IsAdjacentTo(Territory.FrenchEquatorialAfrica));
            Assert.That(Territory.BelgianCongo.IsAdjacentTo(Territory.Angola));

            Assert.That(Territory.SouthAfrica.IsAdjacentTo(Territory.SouthAfricaSea));
            Assert.That(Territory.SouthAfrica.IsAdjacentTo(Territory.Mozambique));
            Assert.That(Territory.SouthAfrica.IsAdjacentTo(Territory.Angola));
            Assert.That(Territory.SouthAfrica.IsAdjacentTo(Territory.AngolaSea));

            Assert.That(Territory.KenyaRhodesia.IsAdjacentTo(Territory.MadagascarSea));
            Assert.That(Territory.KenyaRhodesia.IsAdjacentTo(Territory.Angola));
            Assert.That(Territory.KenyaRhodesia.IsAdjacentTo(Territory.Mozambique));
            Assert.That(Territory.KenyaRhodesia.IsAdjacentTo(Territory.ItalianEastAfrica));

            Assert.That(Territory.AngloEgyptSudan.IsAdjacentTo(Territory.EastMediterraneanSea));
            Assert.That(Territory.AngloEgyptSudan.IsAdjacentTo(Territory.RedSea));
            Assert.That(Territory.AngloEgyptSudan.IsAdjacentTo(Territory.Libya));
            Assert.That(Territory.AngloEgyptSudan.IsAdjacentTo(Territory.ItalianEastAfrica));
        }

        [Test]
        public void Asia()
        {
            Assert.That(Territory.Kazakh.IsAdjacentTo(Territory.CaspianSea));
            Assert.That(Territory.Kazakh.IsAdjacentTo(Territory.CaspianSea));

            Assert.That(Territory.Sinkiang.IsAdjacentTo(Territory.China));
            Assert.That(Territory.Sinkiang.IsAdjacentTo(Territory.Mongolia));
            Assert.That(Territory.Sinkiang.IsAdjacentTo(Territory.Kazakh));
            Assert.That(Territory.Sinkiang.IsAdjacentTo(Territory.India));
            Assert.That(Territory.Sinkiang.IsAdjacentTo(Territory.Afghan));
            Assert.That(Territory.Sinkiang.IsAdjacentTo(Territory.FrenchIndoChina));
        }

        [Test]
        public void North_America()
        {
            Assert.That(Territory.EasternUsa.IsAdjacentTo(Territory.EasternCanada));
            Assert.That(Territory.EasternUsa.IsAdjacentTo(Territory.WesternUsa));
            Assert.That(Territory.EasternUsa.IsAdjacentTo(Territory.EasternUsaSea));

            Assert.That(Territory.WestIndies.IsAdjacentTo(Territory.CaribbeanSea));
        }
    }
}
