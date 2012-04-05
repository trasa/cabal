using System.Windows;

namespace Cabal.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        public App()
        {
            ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
            Startup += Application_Startup;
        }

        private static void Application_Startup(object sender, StartupEventArgs e)
        {
            new Bootstrapper().Run();
        }
    }
}
