using System.Windows;
using Cabal.Client.Core.Api;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Modules.Login.PresentationModels;
using Cabal.Client.Modules.Login.Views;
using Cabal.Core.Shared.Model;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Client.Test.PresentationModels
{
    [TestFixture]
    public class LoginPresentationModelFixture : PresentationModelFixture<ILoginView>
    {
        private LoginPresentationModel viewModel;
        private Mock<IAccountService> accountService;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            accountService =new Mock<IAccountService>();
            viewModel = new LoginPresentationModel(MockView.Object, CommandsProxy, EventAggregator.Object, SessionState, GlobalRegions, accountService.Object)
            {
                UserName = "bob",
                Password = "password1"
            };
        }

        private void DoSuccessfulLogin()
        {
            accountService.Setup(c => c.Login("bob", "password1")).Returns("TOKEN");
            accountService.Setup(c => c.GetActiveGames("bob")).Returns(new[] {new GameDto {Id = 50}});
            viewModel.Login(null);
        }

        private void DoFailLogin()
        {
            accountService.Setup(c => c.Login("bob", "password1")).Returns((string)null);
            viewModel.Login(null);
        }
		
        [Test]
        public void Login_Successful()
        {
            DoSuccessfulLogin();
            Assert.That(string.IsNullOrEmpty(viewModel.ValidationMessage));
            Assert.That(SessionState.AuthToken, Is.EqualTo("TOKEN"));
            Assert.That(viewModel.GamesGridVisibility, Is.EqualTo(Visibility.Visible));
            Assert.That(viewModel.ActiveGames.Count, Is.EqualTo(1));
        }

        [Test]
        public void Login_Failed()
        {
            DoFailLogin();
            Assert.That(viewModel.ValidationMessage, Is.Not.Null);
            Assert.That(SessionState.AuthToken, Is.Null);
            Assert.That(viewModel.GamesGridVisibility, Is.Not.EqualTo(Visibility.Visible));
            Assert.That(viewModel.ActiveGames, Is.Empty);
        }

        [Test]
        public void Can_Login_Success()
        {
            Assert.That(viewModel.CanLogin(null));
            Assert.That(CommandsProxy.LoginCommand.CanExecute(null));
        }

        [Test]
        public void Can_Not_Login_NoPassword()
        {
            viewModel.Password = null;
            Assert.IsFalse(viewModel.CanLogin(null));
            Assert.IsFalse(CommandsProxy.LoginCommand.CanExecute(null));
        }

        [Test]
        public void Can_Not_Login_NoUserName()
        {
            viewModel.UserName = null;
            Assert.IsFalse(viewModel.CanLogin(null));
            Assert.IsFalse(CommandsProxy.LoginCommand.CanExecute(null));
        }

        [Test]
        public void Selecting_A_Game_Fails_If_Not_Logged_In()
        {
            DoFailLogin();
            // haven't logged in yet.
            Assert.IsFalse(viewModel.CanSelectActiveGame(0));
        }

        [Test]
        public void Selecting_A_Game_Succeeds_If_Logged_In()
        {
            DoSuccessfulLogin();
            Assert.That(viewModel.CanSelectActiveGame(0));
        }


        [Test]
        public void Selecting_A_Game_Updates_State_Of_Game()
        {
            // arrange
            SubscribeToEvent<GameSelectedEvent, int>(gameId => Assert.That(gameId, Is.EqualTo(50)));

            // act
            DoSuccessfulLogin();
            viewModel.SelectActiveGame(50);

            // assert
            Assert.That(SessionState.Game.Id, Is.EqualTo(50));
            Assert.That(VerifyEventRaised<GameSelectedEvent>()); 
            GlobalRegions.MockMainRegion.Verify(r => r.Deactivate(MockView.Object));
        }
    }
}
