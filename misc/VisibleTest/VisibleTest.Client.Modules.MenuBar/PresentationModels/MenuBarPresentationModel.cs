using VisibleTest.Client.Core.PresentationModels;
using VisibleTest.Client.Modules.MenuBar.Views;

namespace VisibleTest.Client.Modules.MenuBar.PresentationModels
{
    public interface IMenuBarPresentationModel : IPresentationModel<IMenuBarView>
    {
        
    }

    public class MenuBarPresentationModel : ViewModelBase<IMenuBarView>, IMenuBarPresentationModel
    {
        public MenuBarPresentationModel(IMenuBarView view)
        {
            View = view;
            view.Model = this;
        }
    }
}
