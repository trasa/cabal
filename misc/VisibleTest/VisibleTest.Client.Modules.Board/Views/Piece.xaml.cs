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

namespace VisibleTest.Client.Modules.Board.Views
{
    /// <summary>
    /// Interaction logic for Piece.xaml
    /// </summary>
    public partial class Piece : UserControl
    {
        public Piece()
        {
            InitializeComponent();
        }

        public void SetMarkerImage()
        {
            //            string src = null;
            //            switch (n)
            //            {
            //                case Nationality.None:
            //                    Visibility = Visibility.Collapsed;
            //                    return;
            //
            //                case Nationality.GermanyJapan:
            //                    src = "GermanyJapanMarker.png";
            //                    break;
            //
            //                case Nationality.Germany:
            //                    src = "GermanyMarker.png";
            //                    break;
            //
            //                case Nationality.Japan:
            //                    src = "JapanMarker.png";
            //                    break;
            //
            //                case Nationality.SovietUnionUnitedKingdomUnitedStates:
            //                    src = "UKUSASovietMarker.png";
            //                    break;
            //                case Nationality.SovietUnionUnitedKingdom:
            //                    src = "UKSovietMarker.png";
            //                    break;
            //
            //                case Nationality.SovietUnionUnitedStates:
            //                    src = "UsaSovietMarker.png";
            //                    break;
            //
            //                case Nationality.UnitedKingdomUnitedStates:
            //                    src = "UKUSAMarker.png";
            //                    break;
            //
            //                case Nationality.SovietUnion:
            //                    src = "SovietMarker.png";
            //                    break;
            //
            //                case Nationality.UnitedKingdom:
            //                    src = "UnitedKingdomMarker.png";
            //                    break;
            //                case Nationality.UnitedStates:
            //                    src = "UsaMarker.png";
            //                    break;
            //
            //                
            //            }
            //            Visibility = Visibility.Visible;
            //            src = "pack://application:,,,/Cabal.Client.Modules.Board;component/images/" + src;
            //            Marker.Source = new BitmapImage(new Uri(src));
        }


    }
}
