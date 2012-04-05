using Cabal.Client.Core.Modules;
using Cabal.Client.Modules.Orders.PresentationModels;
using Cabal.Client.Modules.Orders.Views;
using Microsoft.Practices.Composite.Regions;

namespace Cabal.Client.Modules.Orders
{
    public class OrdersModule : StructureMapModule
    {
        private readonly IRegionManager regionManager;

        public OrdersModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public override void Initialize()
        {
            Container.Configure(c =>
                                    {
                                        c.ForRequestedType<IWeaponsPresentationModel>()
                                            .TheDefaultIsConcreteType<WeaponsPresentationModel>()
                                            .AsSingletons();

                                        c.ForRequestedType<IWeaponsView>()
                                            .TheDefaultIsConcreteType<WeaponsView>()
                                            .AsSingletons();

                                        c.ForRequestedType<IWeaponsStatusPresentationModel>()
                                            .TheDefaultIsConcreteType<WeaponsStatusPresentationModel>()
                                            .AsSingletons();

                                        c.ForRequestedType<IWeaponsStatusView>()
                                            .TheDefaultIsConcreteType<WeaponsStatusView>()
                                            .AsSingletons();
                                    });
            Container.AssertConfigurationIsValid();

            var weaponModel = Container.GetInstance<IWeaponsPresentationModel>();
            var statusModel = Container.GetInstance<IWeaponsStatusPresentationModel>();
            
            regionManager.Regions["BottomPanelRegion"].Add(weaponModel.View);
            regionManager.Regions["BottomPanelRegion"].Deactivate(weaponModel.View);

            regionManager.Regions["PopupRegion"].Add(statusModel.View);
        }
    }
}
