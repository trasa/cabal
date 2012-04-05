using Cabal.Client.Core.Api;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Modules.Board.PresentationModels;
using Cabal.Client.Modules.Board.Views;
using Cabal.Core.Shared.Model;
using Moq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Client.Test.PresentationModels
{
    [TestFixture]
    public class BoardPresentationModelFixture : PresentationModelFixture<IBoardView>
    {
        private BoardPresentationModel viewModel;
        private Mock<IBoardService> boardService;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            boardService = new Mock<IBoardService>();
            EventAggregator.Setup(ea => ea.GetEvent<GameSelectedEvent>()).Returns(new GameSelectedEvent());
            viewModel = new BoardPresentationModel(MockView.Object, CommandsProxy, EventAggregator.Object, GlobalRegions, boardService.Object);
        }


        [Test]
        public void When_Territory_Selected_SelectedEvent_Fires()
        {
            // arrange
            var state = new TerritoryStateDto
                            {
                                TerritoryId = 1,
                                ControlledBy = Nationality.UnitedKingdom
                            };
            
            // setup boardService expectations
            boardService.Setup(svc => svc.GetTerritoryState(1))
                .Returns(state);

            SubscribeToEvent<TerritorySelectedEvent, TerritoryStateDto>(dto => Assert.That(dto, Is.SameAs(state)));
            
            // act
            MockView.Raise(view => view.TerritorySelected += null, new TerritorySelectedEventArgs(new LandTerritory(1, "territory", 1)));

            // assert
            Assert.That(VerifyEventRaised<TerritorySelectedEvent>());
        }

        [Test]
        public void When_Refreshing_Map_View_Is_Updated()
        {
            // arrange
            var dto = new TerritoryStateDto();
            boardService.Setup(svc => svc.GetBoardState()).Returns(new[] {dto});
            
            // act
            viewModel.RefreshMap(null);

            // assert
            MockView.Verify(v => v.SetTerritoryView(dto));
        }

        [Test]
        public void When_GameSelected_BoardView_Becomes_Visible_And_Populated()
        {
            viewModel.OnGameSelected(0);

            GlobalRegions.MockMainRegion.Verify(r => r.Activate(MockView.Object));
            boardService.Verify(bs => bs.GetBoardState());
        }
    }
}
