using Cabal.Client.Core.Modules;
using Cabal.Client.Modules.MenuBar.PresentationModels;
using Cabal.Client.Modules.MenuBar.Views;
using Microsoft.Practices.Composite.Regions;

namespace Cabal.Client.Modules.MenuBar
{
    public class MenuBarModule : StructureMapModule
    {
        private readonly IRegionManager regionManager;

        public MenuBarModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public override void Initialize()
        {
            Container.Configure(c =>
                                    {
                                        c.ForRequestedType<IMenuBarPresentationModel>()
                                            .TheDefaultIsConcreteType<MenuBarPresentationModel>()
                                            .AsSingletons();

                                        c.ForRequestedType<IMenuBarView>()
                                            .TheDefaultIsConcreteType<MenuBarView>()
                                            .AsSingletons();
                                    });

            Container.AssertConfigurationIsValid();

            var model = Container.GetInstance<IMenuBarPresentationModel>();
            regionManager.Regions["MenuBarRegion"].Add(model.View);
        }
    }
}
