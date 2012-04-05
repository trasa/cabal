using Cabal.Core.Shared.Exceptions;
using Cabal.Core.Shared.Model;

namespace Cabal.Core.Model
{
    public class GameBoard
    {
        public GameBoard(Game g)
        {
            Game = g;
        }

        public Game Game { get; set; }


        public void Initialize()
        {
            if (Game.GameState != GameState.StartPending)
                throw new InvalidGameStateException("Game must be in StartPending state to initialize the territories.");

            AddGermanUnits();
            AddBritishUnits();
            AddAmericanUnits();
            AddSovietUnits();
            AddJapaneseUnits();
        }

        #region private void AddGermanUnits() { ... }
        private void AddGermanUnits()
        {
            AddUnits(Nationality.Germany, MilitaryUnit.Infantry,
                     new Placement(Territory.Germany, 4),
                     new Placement(Territory.EasternEurope, 3),
                     new Placement(Territory.Ukraine, 3),
                     new Placement(Territory.SouthernEurope, 2),
                     new Placement(Territory.WesternEurope, 2),
                     new Placement(Territory.FinlandNorway, 3),
                     new Placement(Territory.Algeria, 1),
                     new Placement(Territory.Libya, 1)
                );

            AddUnits(Nationality.Germany, MilitaryUnit.Armor,
                     new Placement(Territory.Germany, 2),
                     new Placement(Territory.EasternEurope, 1),
                     new Placement(Territory.Ukraine, 2),
                     new Placement(Territory.SouthernEurope, 1),
                     new Placement(Territory.WesternEurope, 2),
                     new Placement(Territory.FinlandNorway, 1),
                     new Placement(Territory.Libya, 1)
                );

            AddUnits(Nationality.Germany, MilitaryUnit.Fighter,
                     new Placement(Territory.Germany, 1),
                     new Placement(Territory.EasternEurope, 1),
                     new Placement(Territory.Ukraine, 1),
                     new Placement(Territory.WesternEurope, 1),
                     new Placement(Territory.FinlandNorway, 1)
                );

            AddUnits(Nationality.Germany, MilitaryUnit.Bomber,
                     new Placement(Territory.Germany, 1)
                );

            AddUnits(Nationality.Germany, MilitaryUnit.Antiaircraft,
                     new Placement(Territory.Germany, 1),
                     new Placement(Territory.SouthernEurope, 1),
                     new Placement(Territory.WesternEurope, 1)
                );

            AddUnits(Nationality.Germany, MilitaryUnit.Battleship,
                     new Placement(Territory.MediterraneanSea, 1)
                );

            // No Aircraft Carriers

            AddUnits(Nationality.Germany, MilitaryUnit.Transport,
                     new Placement(Territory.BalticSea, 1),
                     new Placement(Territory.MediterraneanSea, 1)
                );

            AddUnits(Nationality.Germany, MilitaryUnit.Submarine,
                     new Placement(Territory.BalticSea, 1),
                     new Placement(Territory.SpanishAtlantic, 1)
                );

            AddUnits(Nationality.Germany, MilitaryUnit.IndustrialComplex,
                     new Placement(Territory.Germany, 1),
                     new Placement(Territory.SouthernEurope, 1)
                );

            // other controlled territories w/out units:
            // Germany has none.
        }
        #endregion

        #region private void AddBritishUnits() { ... }
        private void AddBritishUnits()
        {
            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.Infantry,
                     new Placement(Territory.UnitedKingdom, 2),
                     new Placement(Territory.WesternCanada, 1),
                     new Placement(Territory.Australia, 2),
                     new Placement(Territory.India, 2),
                     new Placement(Territory.SyriaIraq, 1),
                     new Placement(Territory.SouthAfrica, 1),
                     new Placement(Territory.AngloEgyptSudan, 1)
                );
            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.Armor,
                     new Placement(Territory.UnitedKingdom, 1),
                     new Placement(Territory.EasternCanada, 1),
                     new Placement(Territory.AngloEgyptSudan, 1)
                );
            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.Fighter,
                     new Placement(Territory.UnitedKingdom, 2),
                     new Placement(Territory.India, 1)
                );
            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.Bomber,
                new Placement(Territory.UnitedKingdom, 1)
                );
            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.Antiaircraft,
                new Placement(Territory.UnitedKingdom, 1)
                );
            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.Battleship,
                     new Placement(Territory.EnglishChannel, 1),
                     new Placement(Territory.GibraltarMediterraneanSea, 1)
                );
            
            // No Aircraft Carriers

            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.Transport,
                     new Placement(Territory.EnglishChannel, 1),
                     new Placement(Territory.EasternCanadaSea, 1),
                     new Placement(Territory.IndianOcean, 1)
                );
            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.Submarine,
                new Placement(Territory.RedSea, 1) 
                );
            AddUnits(Nationality.UnitedKingdom, MilitaryUnit.IndustrialComplex,
                     new Placement(Territory.UnitedKingdom, 1)
                );

            // Territories controlled but without units:
            SetControlledBy(Nationality.UnitedKingdom,
                            Territory.FrenchWestAfrica,
                            Territory.FrenchEquatorialAfrica,
                            Territory.ItalianEastAfrica,
                            Territory.Persia,
                            Territory.BelgianCongo,
                            Territory.KenyaRhodesia,
                            Territory.Madagascar,
                            Territory.NewZealand,
                            Territory.Gibraltar
                );


        }
        #endregion

        #region private void AddAmericanUnits() { ... }
        private void AddAmericanUnits()
        {
            AddUnits(Nationality.UnitedStates, MilitaryUnit.Infantry,
                new Placement(Territory.EasternUsa, 2),
                new Placement(Territory.WesternUsa, 2),
                new Placement(Territory.Alaska, 1),
                new Placement(Territory.HawaiianIslands, 1),
                new Placement(Territory.MidwayIsland, 1),
                new Placement(Territory.China, 2),
                new Placement(Territory.Sinkiang, 2)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.Armor,
                new Placement(Territory.EasternUsa, 1)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.Fighter,
                new Placement(Territory.EasternUsa, 1),
                new Placement(Territory.WesternUsa, 1),
                new Placement(Territory.HawaiianIslandsSea, 1),
                new Placement(Territory.China, 1)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.Bomber,
                new Placement(Territory.EasternUsa, 1)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.Antiaircraft,
                new Placement(Territory.EasternUsa, 1),
                new Placement(Territory.WesternUsa, 1)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.Battleship,
                new Placement(Territory.WesternUsaSea, 1)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.AircraftCarrier,
                new Placement(Territory.HawaiianIslandsSea, 1)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.Transport,
                new Placement(Territory.EasternUsaSea, 1),
                new Placement(Territory.WesternUsaSea, 1),
                new Placement(Territory.HawaiianIslandsSea, 1)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.Submarine,
                new Placement(Territory.HawaiianIslandsSea, 1)
                );

            AddUnits(Nationality.UnitedStates, MilitaryUnit.IndustrialComplex,
                new Placement(Territory.EasternUsa, 1),
                new Placement(Territory.WesternUsa, 1)
                );

            // Controlled Territories without units:
            SetControlledBy(Nationality.UnitedStates,
                            Territory.Mexico,
                            Territory.Panama,
                            Territory.WestIndies,
                            Territory.Brazil
                );
        }

        #endregion

        #region private void AddSovietUnits() { ... }
        private void AddSovietUnits()
        {
            AddUnits(Nationality.SovietUnion, MilitaryUnit.Infantry,
                     new Placement(Territory.Russia, 4),
                     new Placement(Territory.Karelia, 3),
                     new Placement(Territory.Caucasus, 5),
                     new Placement(Territory.Evenki, 2),
                     new Placement(Territory.Yakut, 3),
                     new Placement(Territory.SovietFarEastSea, 2)
                );

            AddUnits(Nationality.SovietUnion, MilitaryUnit.Armor,
                new Placement(Territory.Russia, 2),
                new Placement(Territory.Karelia, 1),
                new Placement(Territory.SovietFarEast, 1)
                );

            AddUnits(Nationality.SovietUnion, MilitaryUnit.Fighter, 
                new Placement(Territory.Russia, 1),
                new Placement(Territory.Karelia, 1)
                );

            // no bombers

            AddUnits(Nationality.SovietUnion, MilitaryUnit.Antiaircraft,
                new Placement(Territory.Russia, 1),
                new Placement(Territory.Karelia, 1)
                );
            
            // no battleships

            // no aircraft carriers

            AddUnits(Nationality.SovietUnion, MilitaryUnit.Transport,
                new Placement(Territory.BarentsSea, 1)
                );

            AddUnits(Nationality.SovietUnion, MilitaryUnit.Submarine,
                new Placement(Territory.BarentsSea, 1)
                );

            AddUnits(Nationality.SovietUnion, MilitaryUnit.IndustrialComplex,
                new Placement(Territory.Russia, 1),
                new Placement(Territory.Karelia, 1)
                );

            // Controlled Territories without Units
            SetControlledBy(Nationality.SovietUnion,
                Territory.Kazakh,
                Territory.Novosibirsk
                );
        }
        #endregion

        #region private void AddJapaneseUnits() { ... }
        private void AddJapaneseUnits()
        {
            AddUnits(Nationality.Japan, MilitaryUnit.Infantry,
                     new Placement(Territory.Japan, 3),
                     new Placement(Territory.Manchuria, 3),
                     new Placement(Territory.FrenchIndoChina, 2),
                     new Placement(Territory.Okinawa, 1),
                     new Placement(Territory.WakeIsland, 1),
                     new Placement(Territory.PhilipineIslands, 2),
                     new Placement(Territory.CarolineIslands, 1),
                     new Placement(Territory.Kwangtung, 2),
                     new Placement(Territory.EastIndies, 1),
                     new Placement(Territory.BorneoCelebes, 1),
                     new Placement(Territory.NewGuinea, 1),
                     new Placement(Territory.SolomonIslands, 1)
                );

            AddUnits(Nationality.Japan, MilitaryUnit.Armor,
                new Placement(Territory.Japan, 1)
                );

            AddUnits(Nationality.Japan, MilitaryUnit.Fighter,
                new Placement(Territory.Japan, 1),
                new Placement(Territory.Manchuria, 1),
                new Placement(Territory.FrenchIndoChina, 1),
                new Placement(Territory.PhilipineIslands, 1),
                new Placement(Territory.CarolineIslandsSea, 1)  // AC
                );

            AddUnits(Nationality.Japan, MilitaryUnit.Bomber,
                     new Placement(Territory.Japan, 1)
                );

            AddUnits(Nationality.Japan, MilitaryUnit.Antiaircraft,
                new Placement(Territory.Japan, 1)
                );

            AddUnits(Nationality.Japan, MilitaryUnit.Battleship,
                new Placement(Territory.SeaOfJapan, 1),
                new Placement(Territory.CarolineIslandsSea, 1)
                );

            AddUnits(Nationality.Japan, MilitaryUnit.AircraftCarrier,
                     new Placement(Territory.CarolineIslandsSea, 1)
                );

            AddUnits(Nationality.Japan, MilitaryUnit.Transport, 
                new Placement(Territory.SeaOfJapan, 1),
                new Placement(Territory.PhilipineIslandsSea, 1)
                );

            AddUnits(Nationality.Japan, MilitaryUnit.Submarine,
                new Placement(Territory.SolomonIslandsSea, 1)
                );

            AddUnits(Nationality.Japan, MilitaryUnit.IndustrialComplex,
                     new Placement(Territory.Japan, 1)
                );

            // Controlled Territories without Armies
            // None
        }
        #endregion

        private void AddUnits(Nationality nationality, MilitaryUnit unitType, params Placement[] placements)
        {
            foreach (Placement p in placements)
            {
                TerritoryState t = Game.GetTerritory(p.Territory);
                t.ControlledBy = nationality;
                t.AddUnits(nationality, unitType, p.UnitCount);
            }
        }

        private void SetControlledBy(Nationality nationality, params Territory[] territories)
        {
            foreach(Territory t in territories)
            {
                TerritoryState ts = Game.GetTerritory(t);
                ts.ControlledBy = nationality;
            }
        }

        #region Nested type: Placement

        private class Placement
        {
            public Placement(Territory t, int units)
            {
                Territory = t;
                UnitCount = units;
            }

            public Territory Territory { get; private set; }
            public int UnitCount { get; private set; }
        }

        #endregion
    }
}