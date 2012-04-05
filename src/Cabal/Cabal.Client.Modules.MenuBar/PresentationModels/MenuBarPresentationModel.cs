using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cabal.Client.Core.PresentationModels;
using Cabal.Client.Modules.MenuBar.Views;

namespace Cabal.Client.Modules.MenuBar.PresentationModels
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
