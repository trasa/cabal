using System;
using System.Threading;
using Blackfin.Core.Exceptions;
using Cabal.Client.Core.Infrastructure;
using Cabal.Client.Core.Model;
using Cabal.Client.Core.Views;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Regions;
using Moq;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Cabal.Client.Core.Services
{
    public class CabalClientRegistry : Registry
    {
        public CabalClientRegistry()
        {
            Scan(scan =>
                     {
                         scan.TheCallingAssembly();
                         scan.AssemblyContainingType(typeof(IView<>));
                         scan.WithDefaultConventions();

                         ForRequestedType<IGlobalCommandsProxy>()
                             .TheDefaultIsConcreteType<GlobalCommandsProxy>()
                             .AsSingletons();

                         ForRequestedType<IEventAggregator>()
                             .TheDefaultIsConcreteType<EventAggregator>()
                             .AsSingletons();

                         ForRequestedType<SessionState>()
                             .TheDefaultIsConcreteType<SessionState>()
                             .AsSingletons();
                     });
        }
    }

    public static class ClientIoCContainer
    {
        public static IContainer Container { get; set; }

        public static ContainerOptions Configure()
        {
            if (Container == null)
                throw new InvalidStateException("You must set the Container property before configuring.");

            return new ContainerOptions(Container);
        }

        public class ContainerOptions
        {
            private readonly IContainer container;

            public ContainerOptions(IContainer container)
            {
                this.container = container;
                container.Configure( c=> c.AddRegistry<CabalClientRegistry>());
            }

            public ContainerOptions ForTest()
            {
                container.Configure(
                    c => c.ForRequestedType<IRegionManager>().TheDefault.IsThis(new Mock<IRegionManager>().Object));
                return this;
            }

            public ContainerOptions ForClient()
            {
                container.Configure(
                    c =>
                    {
                        c.ForRequestedType<IGlobalRegions>()
                            .TheDefaultIsConcreteType<GlobalRegions>()
                            .AsSingletons();
                        c.ForRequestedType<IGlobalCommandsProxy>().TheDefaultIsConcreteType<GlobalCommandsProxy>();
                    });
                return this;
            }
        }
    }
}
