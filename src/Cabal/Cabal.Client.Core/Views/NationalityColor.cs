using System.Windows.Media;
using Cabal.Core.Shared.Model;

namespace Cabal.Client.Core.Views
{
    public static class NationalityColor
    {
        public static readonly double Opacity = 0.40;
        public static readonly double HighlightOpacity = Opacity * 3;

        public static readonly Brush Germany = new SolidColorBrush(Color.FromRgb(0xd0, 0xd6, 0xc9));
        public static readonly Brush Japan = new SolidColorBrush(Color.FromRgb(0xdd, 0xcb, 0x3e));

        public static readonly Brush SovietUnion = new SolidColorBrush(Color.FromRgb(0xc2, 0x96, 0x36));
        public static readonly Brush UnitedStates = new SolidColorBrush(Color.FromRgb(0x62, 0x75, 0x35));
        public static readonly Brush UnitedKingdom = new SolidColorBrush(Color.FromRgb(0xcd, 0xa4, 0x34));

        public static readonly Brush Sea = new SolidColorBrush(Color.FromRgb(0x54, 0x91, 0xc9));

        public static readonly Brush None = Brushes.Transparent;

        public static Brush GetColor(Nationality nationality)
        {
            switch (nationality)
            {
                case Nationality.Germany:
                    return Germany;
                case Nationality.Japan:
                    return Japan;
                case Nationality.SovietUnion:
                    return SovietUnion;
                case Nationality.UnitedKingdom:
                    return UnitedKingdom;
                case Nationality.UnitedStates:
                    return UnitedStates;
                default:
                    return None;
            }
        }
    }
}
