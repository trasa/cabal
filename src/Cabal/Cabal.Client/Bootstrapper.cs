using System.Windows;
using Cabal.Client.Core.Services;
using Cabal.Client.Modules.Board;
using Cabal.Client.Modules.Login;
using Cabal.Client.Modules.MenuBar;
using Cabal.Client.Modules.Orders;
using Cabal.Client.Modules.TerritoryStats;
using CompositeWPFContrib.Composite.StructureMapExtensions;
using Microsoft.Practices.Composite.Modularity;
using StructureMap;

namespace Cabal.Client
{
    public class Bootstrapper : StructureMapBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var shell = Container.GetInstance<Shell>();
            shell.Show();
            return shell;
        }

        protected override IModuleCatalog GetModuleCatalog()
        {
            return new ModuleCatalog()
                .AddModule(typeof(BoardModule))
                .AddModule(typeof(MenuBarModule))
                .AddModule(typeof(TerritoryStatsModule))
                .AddModule(typeof(LoginModule))
                .AddModule(typeof(OrdersModule));
        }

        protected override IContainer CreateContainer()
        {
            ClientIoCContainer.Container = new Container();
            return ClientIoCContainer.Container;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ClientIoCContainer.Configure().ForClient();
            Container.AssertConfigurationIsValid();
        }
    }
}
