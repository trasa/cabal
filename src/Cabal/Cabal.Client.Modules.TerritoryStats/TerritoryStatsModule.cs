using Cabal.Client.Core.Modules;
using Cabal.Client.Modules.TerritoryStats.PresentationModels;
using Cabal.Client.Modules.TerritoryStats.Views;
using Microsoft.Practices.Composite.Regions;

namespace Cabal.Client.Modules.TerritoryStats
{
    public class TerritoryStatsModule : StructureMapModule
    {
        private readonly IRegionManager regionManager;

        public TerritoryStatsModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public override void Initialize()
        {
            Container.Configure(c =>
                                    {
                                        c.ForRequestedType<ITerritoryStatsPresentationModel>()
                                            .TheDefaultIsConcreteType
                                            <TerritoryStatsPresentationModel>()
                                            .AsSingletons();

                                        c.ForRequestedType<ITerritoryStatsView>()
                                            .TheDefaultIsConcreteType<TerritoryStatsView>()
                                            .AsSingletons();
                                    });

            Container.AssertConfigurationIsValid();

            var model = Container.GetInstance<ITerritoryStatsPresentationModel>();
            regionManager.Regions["LeftPanelRegion"].Add(model.View);
        }
    }
}
