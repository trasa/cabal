using Cabal.Client.Core.Views;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Client.Test.Views
{
    [TestFixture]
    public class NationalityMarkerFixture
    {
        [Test]
        public void GetMarker()
        {
            string marker = NationalityMarker.GetMarker(Nationality.UnitedStates);
            Assert.That(marker, Is.EqualTo(NationalityMarker.UnitedStates));
        }
    }
}
