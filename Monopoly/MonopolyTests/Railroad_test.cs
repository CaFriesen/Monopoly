using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class Railroad_test
    {
        [TestMethod]
        public void RailRoadTest_ConstructorShouldMakeNewRailRoad()
        {
            Railroad testRailroad = new Railroad(1, 100, 50, "Station Eindhoven", 111, 110, 100);

            Assert.AreEqual(1, testRailroad.SquareId);
            Assert.AreEqual(100, testRailroad.Price);
            Assert.AreEqual(50, testRailroad.Rent);
            Assert.AreEqual("Station Eindhoven", testRailroad.Name);
            Assert.AreEqual(111, testRailroad.Color.R);
            Assert.AreEqual(110, testRailroad.Color.G);
            Assert.AreEqual(100, testRailroad.Color.B);
            Assert.AreEqual(true, testRailroad.Available);
        }

        [TestMethod]
        public void RailRoadTest_PlayerShouldBeAbleToBuyRailRoad()
        {
            Railroad testRailroad = new Railroad(1, 100, 50, "Station Eindhoven", 111, 110, 100);

            Player player = new Player();
            player.Cash = 3000;

            testRailroad.Buy(player);

            Assert.AreEqual(player, testRailroad.Owner);
            Assert.AreEqual(testRailroad, player.RealEstates[0]);
            Assert.AreEqual(2900, player.Cash);
            Assert.AreEqual(false, testRailroad.Available);
            Assert.AreEqual(50, testRailroad.Rent);
        }

        [TestMethod]
        public void RailRoadTest_RentShouldGoUpIfPlayerBuysMultipleRailroads()
        {
            Railroad testRailroad1 = new Railroad(1, 100, 50, "Station Eindhoven", 111, 110, 100);
            Railroad testRailroad2 = new Railroad(2, 100, 50, "Station Eindhoven", 111, 110, 100);
            Railroad testRailroad3 = new Railroad(3, 100, 50, "Station Eindhoven", 111, 110, 100);
            Railroad testRailroad4 = new Railroad(4, 100, 50, "Station Eindhoven", 111, 110, 100);

            Player player = new Player();
            player.Cash = 3000;

            testRailroad1.Buy(player);
            Assert.AreEqual(50, testRailroad1.Rent);

            testRailroad2.Buy(player);
            Assert.AreEqual(100, testRailroad1.Rent);
            Assert.AreEqual(100, testRailroad2.Rent);

            testRailroad3.Buy(player);
            Assert.AreEqual(150, testRailroad1.Rent);
            Assert.AreEqual(150, testRailroad2.Rent);
            Assert.AreEqual(150, testRailroad3.Rent);

            testRailroad4.Buy(player);
            Assert.AreEqual(200, testRailroad1.Rent);
            Assert.AreEqual(200, testRailroad2.Rent);
            Assert.AreEqual(200, testRailroad3.Rent);
            Assert.AreEqual(200, testRailroad4.Rent);
        }

        [TestMethod]
        public void RailRoadTest_PlayerShouldPayRentAtRailRoad()
        {
            Railroad testRailroad = new Railroad(1, 100, 50, "Station Eindhoven", 111, 110, 100);

            Player player1 = new Player();
            player1.Cash = 3000;

            Player player2 = new Player();
            player2.Cash = 3000;

            testRailroad.Buy(player1);

            testRailroad.Action(player2);

            Assert.AreEqual(2950, player2.Cash);
            Assert.AreEqual(2950, player1.Cash);
        }
    }
}
