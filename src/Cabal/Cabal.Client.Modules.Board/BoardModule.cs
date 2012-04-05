using Cabal.Client.Core.Modules;
using Cabal.Client.Modules.Board.PresentationModels;
using Cabal.Client.Modules.Board.Views;
using Microsoft.Practices.Composite.Regions;

namespace Cabal.Client.Modules.Board
{
    public class BoardModule : StructureMapModule
    {
        private readonly IRegionManager regionManager;

        public BoardModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public override void Initialize()
        {
            Container.Configure(c =>
                                    {
                                        c.ForRequestedType<IBoardView>()
                                            .TheDefaultIsConcreteType<BoardView>()
                                            .AsSingletons();

                                        c.ForRequestedType<IBoardPresentationModel>()
                                            .TheDefaultIsConcreteType<BoardPresentationModel>()
                                            .AsSingletons();
                                    });

            Container.AssertConfigurationIsValid();

            var model = Container.GetInstance<IBoardPresentationModel>();
            regionManager.Regions["MainRegion"].Add(model.View);
//            regionManager.Regions["MainRegion"].Activate(model.View);
        }
    }
}
