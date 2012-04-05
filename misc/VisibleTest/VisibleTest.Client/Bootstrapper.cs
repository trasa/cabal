using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using CompositeWPFContrib.Composite.StructureMapExtensions;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Modularity;
using StructureMap;
using VisibleTest.Client.Core.Infrastructure;
using VisibleTest.Client.Modules.Board;
using VisibleTest.Client.Modules.MenuBar;

namespace VisibleTest.Client
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
                .AddModule(typeof(MenuBarModule));
        }

        protected override void ConfigureContainer()
        {
            ObjectFactory.Configure(c =>
                                        {
                                            c.ForRequestedType<IEventAggregator>()
                                                .TheDefaultIsConcreteType<EventAggregator>()
                                                .AsSingletons();
                                            
                                            c.Scan(scan =>
                                                       {
                                                           scan.AssemblyContainingType<Bootstrapper>();
                                                           scan.AssemblyContainingType<GlobalCommandsProxy>();
//                                                           scan.AssemblyContainingType<BoardModule>();
//                                                           scan.AssemblyContainingType<MenuBarModule>();
                                                           scan.WithDefaultConventions();
                                                       });

                                        });
            base.ConfigureContainer();
            ObjectFactory.AssertConfigurationIsValid();
        }
    }
}
