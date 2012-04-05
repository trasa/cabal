using System.Windows;
using Cabal.Client.Core.Views;
using Cabal.Client.Modules.Orders.PresentationModels;

namespace Cabal.Client.Modules.Orders.Views
{
    public interface IWeaponsView : IView<IWeaponsPresentationModel>
    {
        
    }

    /// <summary>
    /// Interaction logic for WeaponsView.xaml
    /// </summary>
    public partial class WeaponsView : IWeaponsView
    {
        public WeaponsView()
        {
            InitializeComponent();
        }

        public IWeaponsPresentationModel Model
        {
            get { return (IWeaponsPresentationModel)DataContext; }
            set { DataContext = value; }
        }

        private void CheckStatus_Click(object sender, RoutedEventArgs e)
        {
            Model.ShowStatus();
        }
    }
}
