using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Services;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Services
{
    [TestFixture]
    public class PlayerServiceFixture 
    {
        private PlayerService playerService;
        Mock<IPlayerRepository> playerRepo;
        Mock<IMembershipService> membershipService;

        [SetUp]
        public void SetUp()
        {
            membershipService = new Mock<IMembershipService>();
            playerRepo = new Mock<IPlayerRepository>();
            playerService = new PlayerService(membershipService.Object, playerRepo.Object);
        }



        [Test]
        public void Create_New_Player_With_Existing_UserName()
        {
            playerRepo.Setup(r => r.GetByName("test")).Returns(new Player());

            MembershipCreateStatus status = playerService.CreatePlayer("test", "pw", "email");
            Assert.That(status, Is.EqualTo(MembershipCreateStatus.DuplicateUserName));
        }

        [Test]
        public void Create_New_Player_Success()
        {
            MembershipCreateStatus status = playerService.CreatePlayer("test", "pw", "email");
            
            Assert.That(status, Is.EqualTo(MembershipCreateStatus.Success));
            playerRepo.Verify(r => r.Save(It.IsAny<Player>()));
            membershipService.Verify(s => s.CreateUser("test", "pw", "email"));
        }
    }
}
