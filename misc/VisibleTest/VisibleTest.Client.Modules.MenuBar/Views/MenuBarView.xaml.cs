using VisibleTest.Client.Core.Views;
using VisibleTest.Client.Modules.MenuBar.PresentationModels;

namespace VisibleTest.Client.Modules.MenuBar.Views
{
    public interface IMenuBarView : IView<IMenuBarPresentationModel>
    {
        
    }

    public partial class MenuBarView : IMenuBarView
    {
        public MenuBarView()
        {
            InitializeComponent();
        }

        
        public IMenuBarPresentationModel Model
        {
            get { return (IMenuBarPresentationModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
