using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    class GameTest
    {
        [TestMethod]
        public void GameTest_RollMovedPlayer()
        {
            Game game = new Game();
            int previousPosistion = game.Players[1].Position;
            game.Roll(1);
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
    }
}
