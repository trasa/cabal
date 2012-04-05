using System;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Blackfin.Core.NHibernate;
using Blackfin.Core.NHibernate.Fluent;
using Blackfin.Core.Permit.Rules;
using Cabal.Core.Config;
using Cabal.Core.Extensions;
using Cabal.Core.Model;
using Cabal.Core.Repositories;
using NHibernate;
using StructureMap;
using StructureMap.Attributes;
using StructureMap.Configuration.DSL;

namespace Cabal.Core.Services
{
    public class CabalRegistry : Registry
    {
        public CabalRegistry()
        {
            Scan(scanner =>
                     {
                         scanner.TheCallingAssembly();
                         scanner.AssemblyContainingType(typeof(GameService));
                         scanner.AssemblyContainingType(typeof(NHibernateConfigurationService));
                         scanner.WithDefaultConventions();
                     });

            ForRequestedType<NHibernateSession>()
                .TheDefaultIsConcreteType<NHibernateSession>()
                .AsSingletons();

            ForRequestedType<INHibernateSettingsProvider>()
                .TheDefaultIsConcreteType<CabalNHibernateSettingsProvider>()
                .AsSingletons();

            ForRequestedType<ISessionFactory>()
                .TheDefault.Is.ConstructedBy(c => ObjectFactory.GetInstance<INHibernateConfigurationService>().CreateSessionFactory());

            ForRequestedType<ICabalSettingsProvider>()
                .TheDefaultIsConcreteType<CabalSettingsProvider>();
            
            ForRequestedType<MembershipProvider>()
                .TheDefault.IsThis(Membership.Provider);

            

            ForRequestedType(typeof(IRepository<>))
                .TheDefaultIsConcreteType(typeof(Repository<>));

            SetAllProperties(x =>
                                 {
                                     // used for ObjectFactory.BuildUp()
                                     x.OfType<IGameRepository>();
                                     x.OfType<IGameService>();
                                     x.OfType<IPlayerService>();
                                 });


            //            ForRequestedType<NerdDinnerDataContext>()
            //            .CacheBy(InstanceScope.HttpContext)
            //            .TheDefault.Is.ConstructedBy(() => new NerdDinnerDataContext());

        }
    }

    public static class IoCContainer
    {
        public static ContainerOptions Configure()
        {
            return new ContainerOptions();
        }

        public class ContainerOptions
        {
            public ContainerOptions()
            {
                ObjectFactory.Initialize(init => init.AddRegistry<CabalRegistry>());
            }

            public ContainerOptions ForTest()
            {
                ObjectFactory.Configure(x =>
                {
                    x.ForRequestedType<ISessionStorage>().TheDefault.IsThis(new SimpleSessionStorage());

                    x.ForRequestedType<IPrincipal>()
                        .TheDefault.Is.ConstructedBy(ctx => Thread.CurrentPrincipal);

                    x.ForRequestedType<IMembershipService>()
                        .TheDefaultIsConcreteType<StubAccountMembershipService>();

                    x.ForRequestedType<Player>()
                        .TheDefault.Is.ConstructedBy(ctx => Thread.CurrentPrincipal.GetPlayer());
                });
                return this;
            }

            public ContainerOptions ForWeb(HttpApplication app)
            {
                ObjectFactory.Configure(x =>
                                            {
                                                x.ForRequestedType<RoleProvider>()
                                                    .TheDefault.IsThis(Roles.Provider);

                                                x.ForRequestedType<IPrincipal>()
                                                    .CacheBy(InstanceScope.Hybrid)
                                                    .TheDefault.Is.ConstructedBy(ctx => HttpContext.Current.User);

                                                x.ForRequestedType<IMembershipService>()
                                                    .CacheBy(InstanceScope.HttpContext)
                                                    .TheDefaultIsConcreteType<AccountMembershipService>();

                                                x.ForRequestedType<Player>()
                                                    .CacheBy(InstanceScope.Hybrid)
                                                    .TheDefault.Is.ConstructedBy(ctx => HttpContext.Current.User.GetPlayer());

                                                x.ForRequestedType<HttpContextBase>()
                                                    .TheDefault.Is.ConstructedBy(
                                                    ctx => new HttpContextWrapper(HttpContext.Current));
                                            });
                return this;
            }
        }
    }

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext context, string controllerName)
        {
            Type controllerType = base.GetControllerType(controllerName);
            if (controllerType == null)
                return null;
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }

    public class StructureMapRuleProvider : IRuleProvider
    {
        public Rule GetRule(Type ruleType)
        {
            return (Rule)ObjectFactory.GetInstance(ruleType);
        }
    }
}
