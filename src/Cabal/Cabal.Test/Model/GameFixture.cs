using System.Linq;
using Blackfin.Core.NUnit;
using Cabal.Core.Services;
using Cabal.Core.Shared.Exceptions;
using Cabal.Core.Model;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class GameFixture
    {
        [SetUp]
        public void SetUp()
        {
            AutoMapperConfiguration.Configure();
        }
		

        [Test]
        public void When_Game_Has_No_Players()
        {
            var g = new Game();
            // waiting on players to sign up:
            Assert.That(g.GameState, Is.EqualTo(GameState.AcceptingPlayers));
        }

        [Test]
        public void When_Game_Has_One_Player()
        {
            var g = new Game { AmericanPlayer = new Player() };
            Assert.That(g.GameState, Is.EqualTo(GameState.AcceptingPlayers));
        }

        [Test]
        public void When_Game_Has_Two_Players()
        {
            var g = new Game
                        {
                            AmericanPlayer = new Player(),
                            BritishPlayer = new Player()
                        };
            Assert.That(g.GameState, Is.EqualTo(GameState.AcceptingPlayers));
        }

        [Test]
        public void When_Game_Has_Three_Players()
        {
            var g = new Game
            {
                AmericanPlayer = new Player(),
                BritishPlayer = new Player(),
                GermanPlayer = new Player(),
            };
            Assert.That(g.GameState, Is.EqualTo(GameState.AcceptingPlayers));
        }

        [Test]
        public void When_Game_Has_Four_Players()
        {
            var g = new Game
            {
                AmericanPlayer = new Player(),
                BritishPlayer = new Player(),
                GermanPlayer = new Player(),
                JapanesePlayer = new Player()
            };
            Assert.That(g.GameState, Is.EqualTo(GameState.AcceptingPlayers));
        }

        [Test]
        public void When_Game_Has_Five_Players()
        {
            var g = new Game
            {
                AmericanPlayer = new Player(),
                BritishPlayer = new Player(),
                GermanPlayer = new Player(),
                JapanesePlayer = new Player(),
                SovietPlayer = new Player()
            };
            Assert.That(g.GameState, Is.EqualTo(GameState.StartPending));
        }


        [Test]
        public void Must_Have_All_Players_To_Start()
        {
            var g = new Game();
            Assert.That(g.HasFullPlayers, Is.False);
            var currentPlayer = new Player();
            g.Owner = currentPlayer;
            
            Assert.IsFalse(g.CanStart(g.Owner));
            Expect.Exception<InvalidGameStateException>(() => g.Start(currentPlayer));
        }

        

        [Test]
        public void Only_Owner_Can_Start_Game()
        {
            Game g = Build.Game();
            var currentPlayer = new Player();
            var owner = new Player();
            g.Owner = owner;
            Assert.IsFalse(g.CanStart(currentPlayer));
            Expect.Exception<InvalidGameStateException>(() => g.Start(currentPlayer));
        }

        [Test]
        public void When_Starting_Game()
        {
            Game g = Build.Game();
            Assert.That(g.IsStarted, Is.False);
            var currentPlayer = new Player();
            g.Owner = currentPlayer;
            
            Assert.IsTrue(g.CanStart(currentPlayer));
            g.Start(currentPlayer);

            Assert.That(g.IsStarted, Is.True);
            Assert.That(g.GameState, Is.EqualTo(GameState.PlayerTurn));
            Assert.That(g.CurrentPlayer, Is.EqualTo(g.SovietPlayer));
        }

        

        [Test]
        public void Game_Has_Only_One_Instance_Of_Each_Territory()
        {
            Game g = Build.Game();
            TerritoryState t = g.GetTerritory(Territory.WesternEurope);
            Assert.That(t.Territory, Is.EqualTo(Territory.WesternEurope));
            Assert.That(t.TerritoryId, Is.EqualTo(Territory.WesternEurope.Id));
            Assert.That(t.Game, Is.EqualTo(g));

            TerritoryState t2 = g.GetTerritory(Territory.WesternEurope);
            Assert.That(t, Is.SameAs(t2));
        }

        [Test]
        public void Get_Current_Player_From_Nationality()
        {
            Game g = Build.Game();
            g.Start(g.Owner);
            Assert.That(g.CurrentNationality, Is.EqualTo(Nationality.SovietUnion));
            Assert.That(g.SovietPlayer, Is.SameAs(g.CurrentPlayer));
        }

        [Test]
        public void Convert_Game_To_GameDto()
        {
            Game g = Build.Game();
            g.Id = 50;
            g.AmericanHeavyBombers = true;
            GameDto dto = g.ToDto();
            Assert.That(dto.Id, Is.EqualTo(g.Id));
            Assert.That(dto.AmericanHeavyBombers, Is.EqualTo(g.AmericanHeavyBombers));
            Assert.That(dto.GermanLongRangeAir, Is.EqualTo(g.GermanLongRangeAir));
        }

        [Test]
        public void Convert_TerritoryStates_To_TerritoryStateDtos()
        {
            Game g = Build.Game();
            g.Id = 50;
            TerritoryState ts = g.GetTerritory(Territory.Afghan);
            ts.ControlledBy = Nationality.SovietUnion;
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.AircraftCarrier, 1);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.Antiaircraft, 2);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.Armor, 3);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.Battleship, 4);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.Bomber, 5);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.Fighter, 6);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.IndustrialComplex, 1);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.Infantry, 8);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.Submarine, 9);
            ts.AddUnits(Nationality.SovietUnion, MilitaryUnit.Transport, 10);


            TerritoryStateDto d = g.TerritoryStateDtos.Single();
            TerritoryStateArmyDto a = d.Armies.Single();

            Assert.That(d.GameId, Is.EqualTo(50));
            Assert.That(d.ControlledBy, Is.EqualTo(Nationality.SovietUnion));

            Assert.That(a.AircraftCarriers, Is.EqualTo(1));
            Assert.That(a.Antiaircraft, Is.EqualTo(2));
            Assert.That(a.Armor, Is.EqualTo(3));
            Assert.That(a.Battleships, Is.EqualTo(4));
            Assert.That(a.Bombers, Is.EqualTo(5));
            Assert.That(a.Fighters, Is.EqualTo(6));
            Assert.That(a.IndustrialComplexes, Is.EqualTo(1));
            Assert.That(a.Infantry, Is.EqualTo(8));
            Assert.That(a.Submarines, Is.EqualTo(9));
            Assert.That(a.Transports, Is.EqualTo(10));
        }
    }
}
