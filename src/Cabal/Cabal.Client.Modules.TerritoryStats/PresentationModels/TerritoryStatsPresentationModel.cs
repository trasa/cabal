using System.Linq;
using System.Windows;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.PresentationModels;
using Cabal.Client.Core.Views;
using Cabal.Client.Modules.TerritoryStats.Views;
using Cabal.Core.Shared.Model;
using Microsoft.Practices.Composite.Events;

namespace Cabal.Client.Modules.TerritoryStats.PresentationModels
{
    public interface ITerritoryStatsPresentationModel : IPresentationModel<ITerritoryStatsView>
    {
        
    }


    public class TerritoryStatsPresentationModel : ViewModelBase<ITerritoryStatsView>, ITerritoryStatsPresentationModel
    {
        private Nationality territoryControlledBy;
        private string territoryName;
        private int ipc;
        private Visibility isCapitalVisibility = Visibility.Hidden;
        private Visibility hasUnitsVisibility = Visibility.Collapsed;
        private Visibility isTerritoryVisible = Visibility.Hidden;

        public TerritoryStatsPresentationModel()
        {
        }

        public TerritoryStatsPresentationModel(ITerritoryStatsView view, IEventAggregator eventAggregator)
        {
            View = view;
            view.Model = this;
            eventAggregator.GetEvent<TerritorySelectedEvent>().Subscribe(TerritorySelected);
        }

        public void TerritorySelected(TerritoryStateDto territoryState)
        {
            if (territoryState != null)
            {
                IsTerritoryVisible = Visibility.Visible;
                TerritoryName = territoryState.Territory.Name;
                TerritoryControlledBy = territoryState.ControlledBy;
                TerritoryIpcValue = territoryState.Territory.ManufacturingPoints;
                IsCapitalVisibility = territoryState.Territory is CapitalTerritory
                                          ? Visibility.Visible
                                          : Visibility.Hidden;
                HasUnitsVisibility = territoryState.Armies.Any() ? Visibility.Visible : Visibility.Collapsed;
                View.UpdateUnitsPanel(territoryState.Armies);
            }
            else
            {
                IsTerritoryVisible = Visibility.Hidden;
                TerritoryName = null;
                TerritoryControlledBy = Nationality.None;
                TerritoryIpcValue = 0;
                IsCapitalVisibility = Visibility.Hidden;
                HasUnitsVisibility = Visibility.Hidden;
            }
        }


        public Visibility IsTerritoryVisible
        {
            get { return isTerritoryVisible; }
            set { isTerritoryVisible = value; InvokePropertyChanged("IsTerritoryVisible"); }
        }


        public Visibility HasUnitsVisibility
        {
            get { return hasUnitsVisibility; }
            set { hasUnitsVisibility = value; InvokePropertyChanged("HasUnitsVisibility"); }
        }

        public string TerritoryName
        {
            get { return territoryName; }
            set { territoryName = value; InvokePropertyChanged("TerritoryName"); }
        }

        public int TerritoryIpcValue
        {
            get { return ipc; }
            set { ipc = value; InvokePropertyChanged("TerritoryIpcValue");}
        }

        public Visibility IsCapitalVisibility
        {
            get { return isCapitalVisibility; }
            set { isCapitalVisibility = value; InvokePropertyChanged("IsCapitalVisibility"); }
        }

        public Nationality TerritoryControlledBy
        {
            get { return territoryControlledBy; }
            set 
            { 
                territoryControlledBy = value; 
                InvokePropertyChanged("TerritoryControlledBy");
                InvokePropertyChanged("TerritoryControlledByImageSource");
            }
        }

        public string TerritoryControlledByImageSource
        {
            get { return NationalityMarker.GetMarker(TerritoryControlledBy); }
        }
    }
}
