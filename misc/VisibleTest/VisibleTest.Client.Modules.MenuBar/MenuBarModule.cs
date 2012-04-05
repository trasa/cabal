using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using StructureMap;
using VisibleTest.Client.Modules.MenuBar.PresentationModels;
using VisibleTest.Client.Modules.MenuBar.Views;

namespace VisibleTest.Client.Modules.MenuBar
{
    public class MenuBarModule : IModule
    {
        private readonly IRegionManager regionManager;

        public MenuBarModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            ObjectFactory.Configure(c =>
                                        {
                                            c.ForRequestedType<IMenuBarView>()
                                                .TheDefaultIsConcreteType<MenuBarView>();

                                            c.ForRequestedType<IMenuBarPresentationModel>()
                                                .TheDefaultIsConcreteType<MenuBarPresentationModel>();
                                        });
//            regionManager.RegisterViewWithRegion("MenuBar", typeof(MenuBarView));
            var model = ObjectFactory.GetInstance<IMenuBarPresentationModel>();
            regionManager.Regions["MenuBar"].Add(model.View);
        }
    }
}
