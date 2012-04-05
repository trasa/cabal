using System.Linq;
using Blackfin.Core.NUnit;
using Cabal.Core.Model;
using Cabal.Core.Shared.Exceptions;
using Cabal.Core.Shared.Model;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Cabal.Test.Model
{
    [TestFixture]
    public class GameBoardFixture
    {
        [Test]
        public void Can_Not_Initialize_Game_Not_Ready_To_Start()
        {
            var board = new GameBoard(new Game());
            Expect.Exception<InvalidGameStateException>(board.Initialize);
        }

        [Test]
        public void Can_Initialize_When_Game_Is_Ready_To_Start()
        {
            var board = new GameBoard(Build.Game());
            board.Initialize();
        }

        [Test]
        public void Can_Not_Initialize_Game_In_Progress()
        {
            var g = Build.Game();
            g.Start(g.Owner);
            var board = new GameBoard(g);
            Expect.Exception<InvalidGameStateException>(board.Initialize);
        }

        [Test]
        public void Set_ControlledBy_State_For_All_Non_Neutral_Territories()
        {
            var g = Build.Game();
            var board = new GameBoard(g);
            board.Initialize();

            var landTerritories = from t in Territory.GetAllTerritories()
                                  where t is LandTerritory && !(t is NeutralTerritory)
                                  select t;
            foreach (Territory t in landTerritories)
            {
                Assert.That(g.GetTerritory(t).ControlledBy, Is.Not.EqualTo(Nationality.None),
                    "Territory wasn't assigned Control: " + t.Name);
            }
        }
    }
}
