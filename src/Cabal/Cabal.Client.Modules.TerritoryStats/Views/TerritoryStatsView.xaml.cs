using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cabal.Client.Core.Views;
using Cabal.Client.Modules.TerritoryStats.PresentationModels;
using Cabal.Core.Shared.Model;

namespace Cabal.Client.Modules.TerritoryStats.Views
{
    public interface ITerritoryStatsView : IView<ITerritoryStatsPresentationModel>
    {
        void UpdateUnitsPanel(IEnumerable<TerritoryStateArmyDto> armies);
    }
    
    
    public partial class TerritoryStatsView : ITerritoryStatsView
    {
        public TerritoryStatsView()
        {
            InitializeComponent();
        }

        public ITerritoryStatsPresentationModel Model
        {
            get { return (ITerritoryStatsPresentationModel)DataContext; }
            set { DataContext = value; }
        }

        public void UpdateUnitsPanel(IEnumerable<TerritoryStateArmyDto> armies)
        {
            UnitsPanel.Children.Clear();
            foreach(var army in armies)
            {
                var unitView = new UnitsView();
                unitView.DataContext = new UnitsPresentationModel(unitView, army);

                UnitsPanel.Children.Add(unitView);
            }
        }
    }
}
