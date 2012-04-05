using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using StructureMap;
using VisibleTest.Client.Modules.Board.PresentationModels;
using VisibleTest.Client.Modules.Board.Views;

namespace VisibleTest.Client.Modules.Board
{
    public class BoardModule : IModule
    {
        private readonly IRegionManager regionManager;

        public BoardModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            ObjectFactory.Configure(c =>
                                        {
                                            c.ForRequestedType<IBoardView>()
                                                .TheDefaultIsConcreteType<BoardView>();

                                            c.ForRequestedType<IBoardPresentationModel>()
                                                .TheDefaultIsConcreteType<BoardPresentationModel>();
                                        });

//            regionManager.RegisterViewWithRegion("MainRegion", typeof(BoardView));
            var model = ObjectFactory.GetInstance<IBoardPresentationModel>();
            regionManager.Regions["MainRegion"].Add(model.View);
        }

    }
}
