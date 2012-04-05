using Cabal.Core.Factories;
using Cabal.Core.Shared.Model;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using Cabal.Core.Services;
using Cabal.Web.Controllers;
using Moq;
using MvcContrib.TestHelper;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Controllers
{
    [TestFixture]
    public class GameControllerFixture 
    {
        private Player currentPlayer;
        private Player cpuPlayer;
        Mock<IGameFactory> gameFactory;
        Mock<IGameRepository> gameRepository;
        Mock<IPlayerRepository> playerRepository;

        private GameController controller;
        
        [SetUp]
        public void SetUp()
        {
            gameFactory = new Mock<IGameFactory>();
            gameRepository = new Mock<IGameRepository>();
            playerRepository = new Mock<IPlayerRepository>();
            currentPlayer = new Player {Id = 2, UserName = "Player"};
            cpuPlayer = new Player {Id = 1, UserName = null};
            controller = new GameController(new StubCurrentPlayerProvider(currentPlayer), gameFactory.Object, gameRepository.Object, playerRepository.Object);
        }


        [Test]
        public void Request_Create_View()
        {
            controller.Create()
                .AssertViewRendered();
        }

        [Test]
        public void Creating_Game_Assigns_Players_Correctly()
        {
            // arrange
            playerRepository.Setup(r => r.GetCpuPlayer()).Returns(cpuPlayer);
            var vm = new CreateGameViewModel
                         {
                             Description = "description",
                             SovietUnion = GameViewModel.PlayerCpu.Cpu,
                             Germany = GameViewModel.PlayerCpu.Open,
                             UnitedKingdom = GameViewModel.PlayerCpu.Self,
                             Japan = GameViewModel.PlayerCpu.Cpu,
                             UnitedStates = GameViewModel.PlayerCpu.Self
                         };
            
            // act
            controller.Create(vm);

            // assert
            // created with correct player settings:
            gameFactory.Verify(f => f.Create(currentPlayer, "description",
                                             cpuPlayer,
                                             null,
                                             currentPlayer,
                                             cpuPlayer,
                                             currentPlayer
                                        ));
        }

        [Test]
        public void When_Requesting_Edit_View_If_Game_Not_Found_Redirect()
        {
            gameRepository.Setup(r => r.Get(50)).Returns((Game)null);
            var result = controller.Edit(-50);
            result.AssertActionRedirect().ToAction<ListController>(c => c.Games("All", null));
        }

        [Test]
        public void When_Requesting_Edit_View_Create_PlayerState_Model()
        {
            const int gameId = 5;
            const string description = "game";

            var game = new Game
                           {
                               Id = gameId,
                               Description = description,
                               AmericanPlayer = currentPlayer,
                               BritishPlayer = cpuPlayer,
                               CreatedBy = currentPlayer,
                               Owner = currentPlayer,
                               GermanPlayer = null,
                               SovietPlayer = null,
                               JapanesePlayer = null,
                           };
            gameRepository.Setup(r => r.Get(gameId)).Returns(game);

            var actionResult = controller.Edit(gameId);
            var vm = actionResult.AssertViewRendered().WithViewData<EditGameViewModel>();

            Assert.That(vm.Id, Is.EqualTo(gameId));
            Assert.That(vm.Description, Is.EqualTo(description));
            
            
            AssertPlayerState(vm.AmericanPlayerState, Nationality.UnitedStates, true, false, false);
            AssertPlayerState(vm.BritishPlayerState, Nationality.UnitedKingdom, false, true, false);
            AssertPlayerState(vm.GermanPlayerState, Nationality.Germany, false, false, true);
            AssertPlayerState(vm.SovietPlayerState, Nationality.SovietUnion, false, false, true);
            AssertPlayerState(vm.JapanesePlayerState, Nationality.Japan, false, false, true);
        }

        private static void AssertPlayerState(EditGameViewModel.PlayerState state, Nationality nationality, bool isSelf, bool isCpu, bool isOpen)
        {
            Assert.That(state.Nationality, Is.EqualTo(nationality));
            Assert.AreEqual(state.IsSelf, isSelf);
            Assert.AreEqual(state.IsCpu, isCpu);
            Assert.AreEqual(state.IsOpen, isOpen);
        }

        [Test]
        public void Editing_Game_Doesnt_Exist()
        {
            gameRepository.Setup(r => r.Get(5)).Returns((Game)null);
            var actionResult = controller.Edit(new EditGameViewModel {Id = 5});
            actionResult.AssertActionRedirect().ToAction<ListController>(c => c.Games("All", null));
        }


        [Test]
        public void Editing_Game_Object_Updated()
        {
            var g = new Game();
            gameRepository.Setup(r => r.Get(5)).Returns(g);

            var vm = new EditGameViewModel
                         {
                             Id = 5,
                             Description = "game",
                         };
            controller.Edit(vm);
            gameRepository.Verify(r => r.Save(g));
        }

        [Test]
        public void Only_Owner_Can_Start_Game_View()
        {
            var owner = new Player {Id = 3, UserName = "bob"};
            var g = new Game {Id = 5, Owner = owner};
            gameRepository.Setup(r => r.Get(5)).Returns(g);

            controller.Start(5).AssertActionRedirect().ToAction<ListController>(c => c.Games(null, null));
        }

        [Test]
        public void Game_Must_Be_In_Start_Pending_State_To_Begin()
        {
            var g = new Game
                        {
                            Id = 5, 
                            Owner = currentPlayer,
                            AmericanPlayer = currentPlayer,
                            BritishPlayer = currentPlayer,
                            SovietPlayer =  currentPlayer,
                            JapanesePlayer = currentPlayer,
                            GermanPlayer = currentPlayer,
                        };
            gameRepository.Setup(r => r.Get(5)).Returns(g);
            controller.Start(5).AssertViewRendered();
        }

        [Test]
        public void When_Starting()
        {
            var g = new Game
            {
                Id = 5,
                Owner = currentPlayer,
                AmericanPlayer = currentPlayer,
                BritishPlayer = currentPlayer,
                SovietPlayer = currentPlayer,
                JapanesePlayer = currentPlayer,
                GermanPlayer = currentPlayer,
            };
            gameRepository.Setup(r => r.Get(5)).Returns(g);
            controller.Start(new StartGameViewModel {Id = 5}).AssertActionRedirect().ToAction<ListController>(c => c.Games(null, null));
            gameRepository.Verify(r => r.Save(g));
        }
    }
}
