using System;
using System.Collections.Generic;
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

    public interface IUnitsView : IView<IUnitsPresentationModel>
    {
    }
    
    public partial class UnitsView : IUnitsView
	{
		public UnitsView()
		{
			InitializeComponent();
		}

        public IUnitsPresentationModel Model
        {
            get { return (IUnitsPresentationModel)DataContext;}
            set { DataContext = value; }
        }
	}
}