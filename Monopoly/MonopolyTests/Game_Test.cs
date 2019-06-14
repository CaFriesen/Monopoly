using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using System;

namespace MonopolyTests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void GameTest_RollMovedPlayer()
        {
            //hey freddy we weten niet goed waarom deze faalt maar we willen wel aantonen dat we met unit testen ook externe bestanden kunnen gebruiken in onze unittests
            Game game = new Game();
            game.fileHandler.Load(@"../../../TestFiles/Gameboard.dat");
            int previousPosistion = game.Players[1].Position;
            game.Roll();
            Assert.AreNotEqual(previousPosistion, game.Players[1].Position);
            Assert.IsTrue(previousPosistion < game.Players[1].Position);
        }

        [TestMethod]
        [ExpectedException(typeof(OffTheBoardException))]
        public void GameTest_GetGameSqaure_OutsideBoard()
        {
            Game game = new Game();
            GameSquare square = game.GetGameSquare(50);
        }

        [TestMethod]
        public void GameTest_Mortage()
        {
            Game game = new Game();
            Player player = new Player();
            RealEstate estate = new Street(6, 100, 4, 50, "The angel islington", 160, 250, 240);
            player.AddRealEstate(estate);
            game.Mortage(estate, player);
            Assert.AreEqual(1600, player.Cash);
            Assert.AreEqual(true, estate.OnMortage);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GameTest_MortageNonEstate()
        {
            Game game = new Game();
            Player player = new Player();
            GameSquare estate = new Jail(6, "The angel islington", 160, 250, 240);
            game.Mortage(estate as RealEstate, player);

        }
    }
}
