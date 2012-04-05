using Cabal.Client.Core.Views;
using Cabal.Client.Modules.Orders.PresentationModels;

namespace Cabal.Client.Modules.Orders.Views
{
    public interface IWeaponsStatusView : IView<IWeaponsStatusPresentationModel>
    {
        
    }

    /// <summary>
    /// Interaction logic for WeaponsStatusView.xaml
    /// </summary>
    public partial class WeaponsStatusView : IWeaponsStatusView
    {
        public WeaponsStatusView()
        {
            InitializeComponent();
        }

        public IWeaponsStatusPresentationModel Model
        {
            get { return (IWeaponsStatusPresentationModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
