using System;
using Cabal.Core.Shared.Model;

namespace Cabal.Client.Core.Views
{
    public class NationalityMarker
    {
        private const string MarkerPrefix = "pack://application:,,,/Cabal.Client.Core;component/Images/";
        private const string MarkerSuffix = "Marker.png";

        public static readonly String None = MarkerPrefix + "None" + MarkerSuffix;
        
        public static readonly String Germany = MarkerPrefix + "Germany" + MarkerSuffix;
        public static readonly String Japan = MarkerPrefix + "Japan" + MarkerSuffix;
        public static readonly String GermanyJapan = MarkerPrefix + "GermanyJapan" + MarkerSuffix;

        public static readonly String SovietUnionUnitedKingdomUnitedStates = MarkerPrefix + "UKUSASoviet" + MarkerSuffix;
        public static readonly String SovietUnionUnitedKingdom = MarkerPrefix + "UKSoviet" + MarkerSuffix;
        public static readonly String SovietUnionUnitedStates = MarkerPrefix + "UsaSoviet" + MarkerSuffix;
        public static readonly String UnitedKingdomUnitedStates = MarkerPrefix + "UKUSA" + MarkerSuffix;
        public static readonly String SovietUnion = MarkerPrefix + "Soviet" + MarkerSuffix;
        public static readonly String UnitedKingdom = MarkerPrefix + "UnitedKingdom" + MarkerSuffix;
        public static readonly String UnitedStates = MarkerPrefix + "Usa" + MarkerSuffix;



        public static string GetMarker(Nationality n)
        {
            switch (n)
            {
                case Nationality.None:
                    return None;

                case Nationality.GermanyJapan:
                    return GermanyJapan;

                case Nationality.Germany:
                    return Germany;

                case Nationality.Japan:
                    return Japan;

                case Nationality.SovietUnionUnitedKingdomUnitedStates:
                    return SovietUnionUnitedKingdomUnitedStates;

                case Nationality.SovietUnionUnitedKingdom:
                    return SovietUnionUnitedKingdom;

                case Nationality.SovietUnionUnitedStates:
                    return SovietUnionUnitedStates;

                case Nationality.UnitedKingdomUnitedStates:
                    return UnitedKingdomUnitedStates;

                case Nationality.SovietUnion:
                    return SovietUnion;

                case Nationality.UnitedKingdom:
                    return UnitedKingdom;

                case Nationality.UnitedStates:
                    return UnitedStates;

                default:
                    throw new ArgumentOutOfRangeException("n", n, "Unknown Nationality");
            }
        }
    }
}
