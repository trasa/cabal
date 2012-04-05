using Cabal.Client.Core.Modules;
using Cabal.Client.Modules.Login.PresentationModels;
using Cabal.Client.Modules.Login.Views;
using Microsoft.Practices.Composite.Regions;

namespace Cabal.Client.Modules.Login
{
    public class LoginModule : StructureMapModule
    {
        private readonly IRegionManager regionManager;

        public LoginModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public override void Initialize()
        {
            Container.Configure(c =>
                                    {
                                        c.ForRequestedType<ILoginView>()
                                            .TheDefaultIsConcreteType<LoginView>()
                                            .AsSingletons();

                                        c.ForRequestedType<ILoginPresentationModel>()
                                            .TheDefaultIsConcreteType<LoginPresentationModel>()
                                            .AsSingletons();
                                    });

            Container.AssertConfigurationIsValid();

            var model = Container.GetInstance<ILoginPresentationModel>();
            regionManager.Regions["MainRegion"].Add(model.View);
            // initial state: Login Panel Active
            regionManager.Regions["MainRegion"].Activate(model.View);
        }
    }
}
