using Cabal.Core.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class TerritoryStateFixture
    {
        [Test]
        public void Get_Territory_By_Id()
        {
            var state = new TerritoryState { TerritoryId = 1 };
            Assert.That(state.Territory.Id, Is.EqualTo(1));
        }

    }
}
