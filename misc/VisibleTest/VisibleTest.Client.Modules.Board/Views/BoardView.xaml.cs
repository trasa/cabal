using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using VisibleTest.Client.Core.Views;
using VisibleTest.Client.Modules.Board.PresentationModels;

namespace VisibleTest.Client.Modules.Board.Views
{

    public interface IBoardView : IView<IBoardPresentationModel>
    {
        void SetVisible();
    }

    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : IBoardView
    {
        public BoardView()
        {
            InitializeComponent();
        }


        public IBoardPresentationModel Model
        {
            get { return (IBoardPresentationModel)DataContext; }
            set { DataContext = value; }
        }

        public void SetVisible()
        {
            Marker.Visibility = Marker.Visibility == System.Windows.Visibility.Visible ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;
        }
    }
}
