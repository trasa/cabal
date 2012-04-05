using System;
using System.Windows;
using Cabal.Client.Core.Api;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.PresentationModels;
using Cabal.Client.Modules.Board.Views;
using Cabal.Core.Shared.Model;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;

namespace Cabal.Client.Modules.Board.PresentationModels
{
    public interface IBoardPresentationModel : IPresentationModel<IBoardView>
    {
    }



    public class BoardPresentationModel : ViewModelBase<IBoardView>, IBoardPresentationModel
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IGlobalRegions globalRegions;
        private readonly IBoardService boardService;

        private readonly DelegateCommand<object> refreshMapCommand;
        private readonly DelegateCommand<object> resetMapPanAndZoomCommand;

        public BoardPresentationModel(IBoardView view, 
            IGlobalCommandsProxy commandsProxy, 
            IEventAggregator eventAggregator,
            IGlobalRegions globalRegions,
            IBoardService boardService)
        {
            this.eventAggregator = eventAggregator;
            this.globalRegions = globalRegions;
            this.boardService = boardService;
            View = view;
            View.Model = this;
            view.TerritorySelected += TerritorySelected;

            refreshMapCommand = new DelegateCommand<object>(RefreshMap, o => true);
            commandsProxy.RefreshMapCommand.RegisterCommand(refreshMapCommand);

            resetMapPanAndZoomCommand = new DelegateCommand<object>(ResetMapPanAndZoom, o => true);
            commandsProxy.ResetMapPanAndZoomCommand.RegisterCommand(resetMapPanAndZoomCommand);

            eventAggregator.GetEvent<GameSelectedEvent>().Subscribe(OnGameSelected);
        }

        public void OnGameSelected(int gameId)
        {
            globalRegions.MainRegion.Activate(View);
            RefreshMap(null);
        }

        private void TerritorySelected(object sender, TerritorySelectedEventArgs e)
        {
            TerritoryStateDto state = boardService.GetTerritoryState(e.Territory.Id);
            eventAggregator.GetEvent<TerritorySelectedEvent>().Publish(state);
        }

        public void RefreshMap(object parameter)
        {
            var dtos = boardService.GetBoardState();
            foreach (var dto in dtos)
            {
                View.SetTerritoryView(dto);
            }
        }

        public void ResetMapPanAndZoom(object parameter)
        {
            View.ResetMap();
        }
    }
}
