using System;
using System.Windows;
using System.Windows.Input;
using Cabal.Client.Core.Infrastructure;
using StructureMap;

namespace Cabal.Client
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell
    {
        public Shell()
        {
            InitializeComponent();
            Loaded += (s, e) => LoadResources();
        }


        private static void LoadResources()
        {
            // Load secondary styles when the XAML Build Action
            // is set to "Content"
            ObjectFactory.Configure(c => 
                c.ForRequestedType<ResourceDictionary>()
                .TheDefault.Is.ConstructedBy(ctx => 
                    (ResourceDictionary)Application.LoadComponent(
                        new Uri("Styles/Styles.xaml",UriKind.Relative))));
        }


        private void Shell_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                GlobalCommands.ResetMapPanAndZoomCommand.Execute(null);
            }
        }

        private void Shell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                GlobalCommands.ResetMapPanAndZoomCommand.Execute(null);
            }
        }
    }
}
