using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class Utility_test
    {
        [TestMethod]
        public void UtilityTest_ConstructorShouldCreateNewUtility()
        {
            Utility utilityTest = new Utility(1, 50, 100, "West Watter", 111, 110, 100);

            Assert.AreEqual(1, utilityTest.SquareId);
            Assert.AreEqual(100, utilityTest.Price);
            Assert.AreEqual("West Watter", utilityTest.Name);
            Assert.AreEqual(111, utilityTest.Color.R);
            Assert.AreEqual(110, utilityTest.Color.G);
            Assert.AreEqual(100, utilityTest.Color.B);
            Assert.AreEqual(true, utilityTest.Available);
        }

        [TestMethod]
        public void UtilityTest_PlayerShouldBeAbleToBuyUtility()
        {
            Utility utilityTest = new Utility(1, 50, 100, "West Watter", 111, 110, 100);

            Player player = new Player();
            player.Cash = 3000;

            utilityTest.Buy(player);

            Assert.AreEqual(player, utilityTest.Owner);
            Assert.AreEqual(false, utilityTest.Available);
            Assert.AreEqual(2900, player.Cash);
            Assert.AreEqual(utilityTest, player.RealEstates[0]);
        }

        [TestMethod]
        public void UtilityTest_PlayerShouldPayRentBasedOnRollOnOwnedUtility()
        {
            Utility utilityTest = new Utility(1, 50, 100, "West Watter", 111, 110, 100);

            Player player1 = new Player();
            player1.Cash = 3000;

            Player player2 = new Player();
            player2.Cash = 3000;
            player2.LastRoll = 5;

            utilityTest.Buy(player1);

            utilityTest.Action(player2);

            Assert.AreEqual(2750, player2.Cash);
            Assert.AreEqual(3150, player1.Cash);
        }
    }
}
