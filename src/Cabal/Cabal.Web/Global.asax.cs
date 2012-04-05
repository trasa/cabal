using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blackfin.Core.NHibernate;
using Blackfin.Core.Permit.Rules;
using Cabal.Core.Services;
using log4net;
using StructureMap;

namespace Cabal.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private WebSessionStorage sessionStorage;

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "GameList", 
                "list/{list}/{id}",
                new { controller="List", action="Games", list="All", id=""}
                );

            routes.MapRoute(
                "GameListJson",
                "listJson/{list}/{id}",
                new { controller = "ListJson", action = "Games", list = "All", id = "" }
                );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            log.Debug("Application start.");

            RegisterRoutes(RouteTable.Routes);

            IoCContainer.Configure().ForWeb(this);
            RuleProviderFactory.RuleProvider = new StructureMapRuleProvider();
            AutoMapperConfiguration.Configure();

            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        public override void Init()
        {
            base.Init();
            // we have to create WebSessionStorage in Init() so we can hook into HttpApplication events
            sessionStorage = new WebSessionStorage(this);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // TODO move this DoThisOnce class somewhere else and give it a less stupid name.
            // we have to initialize NHibernate outside of App_Startup on IIS7, because I don't know why,
            // but otherwise you get pipeline errors.  So only initialize it once.
            DoThisOnce.Instance().OneTime(() =>
                                              {
                                                  ObjectFactory.Configure(x => x.ForRequestedType<ISessionStorage>()
                                                                                   .TheDefault.IsThis(sessionStorage));
                                                  ObjectFactory.AssertConfigurationIsValid();
                                              });
        }
    }

    public class DoThisOnce
    {
        private static readonly object sync = new object();
        private static DoThisOnce instance;
        private bool isDone;

        protected DoThisOnce() {}

        public static DoThisOnce Instance()
        {
            if (instance == null)
            {
                lock (sync)
                {
                    if (instance == null)
                    {
                        instance = new DoThisOnce();
                    }
                }
            }
            return instance;
        }

        public void OneTime(Action action)
        {
            lock(sync)
            {
                if (!isDone)
                {
                    action();
                    isDone = true;
                }
            }
        }
    }
        
}
