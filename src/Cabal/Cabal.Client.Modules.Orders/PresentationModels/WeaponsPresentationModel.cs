using System;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.PresentationModels;
using Cabal.Client.Modules.Orders.Views;
using Microsoft.Practices.Composite.Events;

namespace Cabal.Client.Modules.Orders.PresentationModels
{
    public interface IWeaponsPresentationModel : IPresentationModel<IWeaponsView>
    {
        void ShowStatus();
    }

    public class WeaponsPresentationModel : ViewModelBase<IWeaponsView>, IWeaponsPresentationModel
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IGlobalRegions globalRegions;

        public WeaponsPresentationModel()
        {
        }

        public WeaponsPresentationModel(IWeaponsView view, IEventAggregator eventAggregator, IGlobalRegions globalRegions)
        {
            this.eventAggregator = eventAggregator;
            this.globalRegions = globalRegions;
            View = view;
            View.Model = this;
            eventAggregator.GetEvent<GameSelectedEvent>().Subscribe(OnGameSelected);
        }

        private void OnGameSelected(int gameId)
        {
            globalRegions.BottomPanelRegion.Activate(View);
        }

        public void ShowStatus()
        {
            eventAggregator.GetEvent<ShowWeaponsStatusEvent>().Publish(null);
        }
    }
}
