using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Cabal.Client.Core.Views;
using Cabal.Core.Shared.Model;

namespace Cabal.Client.Modules.Board.Views
{
    /// <summary>
    /// Interaction logic for Piece.xaml
    /// </summary>
    public partial class Piece 
    {
        public Piece()
        {
            InitializeComponent();
        }

        public void SetMarkerImage(Nationality n)
        {
            if (n == Nationality.None)
            {
                Visibility = Visibility.Collapsed;
                return;
            }
            Visibility = Visibility.Visible;
            Marker.Source = new BitmapImage(new Uri(NationalityMarker.GetMarker(n)));
        }
    }
}
