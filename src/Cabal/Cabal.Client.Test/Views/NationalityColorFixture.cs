using Cabal.Client.Core.Views;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Client.Test.Views
{
    [TestFixture]
    public class NationalityColorFixture
    {
        [Test]
        public void Get_Nationality_Colors()
        {
            Assert.That(NationalityColor.GetColor(Nationality.Germany), Is.SameAs(NationalityColor.Germany));
            Assert.That(NationalityColor.GetColor(Nationality.Japan), Is.SameAs(NationalityColor.Japan));
            Assert.That(NationalityColor.GetColor(Nationality.UnitedKingdom), Is.SameAs(NationalityColor.UnitedKingdom));
            Assert.That(NationalityColor.GetColor(Nationality.UnitedStates), Is.SameAs(NationalityColor.UnitedStates));
            Assert.That(NationalityColor.GetColor(Nationality.SovietUnion), Is.SameAs(NationalityColor.SovietUnion));
            Assert.That(NationalityColor.GetColor(Nationality.None), Is.SameAs(NationalityColor.None));
        }
    }
}
