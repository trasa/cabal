using System.Security;
using Blackfin.Core.NUnit;
using Cabal.Core.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class CabalAuthenticationTicketFixture
    {
        private CabalAuthenticationTicket ticket;

        [SetUp]
        public void SetUp()
        {
            ticket = new CabalAuthenticationTicket(new UserState {UserName = "bob"});
        }
		

        [Test]
        public void Tickets_Begin_In_Not_Expired_State()
        {
            Assert.IsFalse(ticket.Expired);
        }

        [Test]
        public void UserName()
        {
            Assert.That(ticket.UserState.UserName, Is.EqualTo("bob"));
            
        }

        [Test]
        public void Tickets_Can_Be_Encrypted()
        {
            Assert.That(ticket.Encrypt(), Is.Not.Null);
        }

        [Test]
        public void Tickets_Can_Be_Decrypted()
        {
            string token = ticket.Encrypt();
            var otherTicket = CabalAuthenticationTicket.Decrypt(token);
            Assert.That(otherTicket, Is.Not.Null);
            Assert.That(otherTicket.UserState.UserName, Is.EqualTo(ticket.UserState.UserName));
            Assert.IsFalse(otherTicket.Expired);
        }

        [Test]
        public void Verify_Success()
        {
            string token = ticket.Encrypt();
            CabalAuthenticationTicket otherTicket = CabalAuthenticationTicket.Verify(token);
            Assert.That(otherTicket.UserState.UserName, Is.EqualTo(ticket.UserState.UserName));
        }

        [Test]
        public void Verify_Fail_Null()
        {
            Expect.Exception<SecurityException>(() => CabalAuthenticationTicket.Verify(null));
            Expect.Exception<SecurityException>(() => CabalAuthenticationTicket.Verify(""));
        }

        [Test]
        public void Verify_Fail_Bad_Ticket()
        {
            Expect.Exception<SecurityException>(() => CabalAuthenticationTicket.Verify("aslkdjflaksjlkasdjfk,asjdf"));
        }

        [Test]
        public void Decrypt_Fail()
        {
            Assert.That(CabalAuthenticationTicket.Decrypt("as,djkf"), Is.Null);
            Assert.That(CabalAuthenticationTicket.Decrypt(null), Is.Null);
            Assert.That(CabalAuthenticationTicket.Decrypt(""), Is.Null);
        }
    }
}
