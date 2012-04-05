using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class TerritoryFixture 
    {
        [Test]
        public void Get_Territory_By_Name()
        {
            Territory t = Territory.GetByName("Western USA");
            Assert.That(t.Name, Is.EqualTo("Western USA"));
        }
    }
}
