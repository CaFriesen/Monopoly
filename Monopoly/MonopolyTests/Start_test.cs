using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.GameSquares;

namespace MonopolyTests
{
    [TestClass]
    public class Start_test
    {
        [TestMethod]
        public void StartTest_ConstructorShouldCreateNewStart()
        {
            Start testStart = new Start(1, "Start", 111, 110, 100);

            Assert.AreEqual(1, testStart.SquareId);
            Assert.AreEqual("Start", testStart.Name);
            Assert.AreEqual(111, testStart.Color.R);
            Assert.AreEqual(110, testStart.Color.G);
            Assert.AreEqual(100, testStart.Color.B);
        }

        [TestMethod]
        public void StartTest_PlayerShouldGetMoneyWhenTheyPassByStart()
        {
            Start testStart = new Start(1, "Start", 111, 110, 100);

            Player player = new Player();
            player.Cash = 3000;

            testStart.Action(player);

            Assert.AreEqual(3200, player.Cash);
        }
    }
}
