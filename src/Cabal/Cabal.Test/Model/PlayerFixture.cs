using Cabal.Core.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class PlayerFixture
    {
        [Test]
        public void Players_Can_Be_Controlled_By_AI()
        {
            var p = new Player();
            Assert.IsTrue(p.IsCpu); // no user

            var p2 = new Player {UserName = "bob"};
            Assert.IsFalse(p2.IsCpu);
        }

        [Test]
        public void DisplayName_Of_Player()
        {
            var p = new Player {UserName = "Bob"};
            var cpu = new Player {UserName = null};

            Assert.That(Player.GetDisplayName(null, p), Is.EqualTo("Open"));
            Assert.That(Player.GetDisplayName(p, null), Is.EqualTo("Bob"));
            Assert.That(Player.GetDisplayName(p, p), Is.EqualTo("Bob [You!]"));
            Assert.That(Player.GetDisplayName(cpu, p), Is.EqualTo("CPU"));
        }
    }
}
