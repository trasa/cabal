using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cabal.Client.Core.Api;
using Cabal.Client.Core.Views;
using Cabal.Client.Modules.MenuBar.PresentationModels;

namespace Cabal.Client.Modules.MenuBar.Views
{
    
    public interface IMenuBarView : IView<IMenuBarPresentationModel>
    {
        
    }

    /// <summary>
    /// Interaction logic for MenuBarView.xaml
    /// </summary>
    public partial class MenuBarView : IMenuBarView
    {
        public MenuBarView()
        {
            InitializeComponent();
        }

        public IMenuBarPresentationModel Model
        {
            get { return (IMenuBarPresentationModel)DataContext; }
            set { DataContext = value; }
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }
    }
}
