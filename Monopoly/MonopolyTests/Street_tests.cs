using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class Street_tests
    {
        [TestMethod]
        public void StreetTest_ConstructorShouldCreateNewStreet()
        {
            Street testStreet = new Street(1, 100, 25, 50, "testStreet", 111, 110, 100);

            Assert.AreEqual(1, testStreet.SquareId);
            Assert.AreEqual(100, testStreet.Price);
            Assert.AreEqual("testStreet", testStreet.Name);
            Assert.AreEqual(111, testStreet.Color.R);
            Assert.AreEqual(110, testStreet.Color.G);
            Assert.AreEqual(100, testStreet.Color.B);
            Assert.AreEqual(true, testStreet.Available);
        }

        [TestMethod]
        public void StreetTest_ActionPlayerShouldBeAbleToBuyStreet()
        {
            Street testStreet = new Street(1, 100, 25, 50, "testStreet", 111, 110, 100);
            Player player = new Player();

            player.Cash = 3000;

            testStreet.Buy(player);

            Assert.AreEqual(2900, player.Cash);
            Assert.AreEqual(player, testStreet.Owner);
            Assert.AreEqual(testStreet, player.RealEstates[0]);
            Assert.AreEqual(false, testStreet.Available);
        }

        [TestMethod]
        public void StreetTest_ActionPlayerShouldPayRentOnOwnedStreet()
        {
            Street testStreet = new Street(1, 100, 25, 50, "testStreet", 111, 110, 100);
            Player player1 = new Player();
            player1.Cash = 3000;
            testStreet.Buy(player1);

            Player player2 = new Player();
            player2.Cash = 3000;

            testStreet.Action(player2);

            Assert.AreEqual(2975, player2.Cash);
            Assert.AreEqual(2925, player1.Cash);
        }

        [TestMethod]
        public void StreetTest_ActionPlayerShouldntPayRentOnTheirOwnedStreet()
        {
            Street testStreet = new Street(1, 100, 25, 50, "testStreet", 111, 110, 100);
            Player player1 = new Player();
            player1.Cash = 3000;
            testStreet.Buy(player1);

            testStreet.Action(player1);
            
            Assert.AreEqual(2900, player1.Cash);
        }

        [TestMethod]
        public void StreetTest_AddHouseAndAddHotelShouldIncreaseLevel()
        {
            Street testStreet = new Street(1, 100, 25, 50, "testStreet", 111, 110, 100);
            Player player = new Player();
            player.Cash = 3000;
            testStreet.Buy(player);

            testStreet.AddHouse();
            Assert.AreEqual(1, testStreet.Level);
            Assert.AreEqual(2850, player.Cash);

            testStreet.AddHouse();
            Assert.AreEqual(2, testStreet.Level);
            Assert.AreEqual(2800, player.Cash);

            testStreet.AddHouse();
            Assert.AreEqual(3, testStreet.Level);
            Assert.AreEqual(2750, player.Cash);

            testStreet.AddHouse();
            Assert.AreEqual(4, testStreet.Level);
            Assert.AreEqual(2700, player.Cash);

            testStreet.AddHotel();
            Assert.AreEqual(5, testStreet.Level);
            Assert.AreEqual(2650, player.Cash);
        }

        [TestMethod]
        public void StreetTest_HouseWithBuildingsRentShouldGoUp()
        {
            Street testStreet = new Street(1, 100, 25, 50, "testStreet", 111, 110, 100);
            Player player1 = new Player();
            player1.Cash = 3000;
            testStreet.Buy(player1);

            Player player2 = new Player();
            player2.Cash = 3000;


            testStreet.AddHouse();
            Assert.AreEqual(50, testStreet.Rent);
            testStreet.Action(player2);
            Assert.AreEqual(2950, player2.Cash);
            Assert.AreEqual(2900, player1.Cash);

            testStreet.AddHouse();
            Assert.AreEqual(100, testStreet.Rent);
            testStreet.Action(player2);
            Assert.AreEqual(2850, player2.Cash);
            Assert.AreEqual(2950, player1.Cash);

            testStreet.AddHouse();
            Assert.AreEqual(150, testStreet.Rent);
            testStreet.Action(player2);
            Assert.AreEqual(2700, player2.Cash);
            Assert.AreEqual(3050, player1.Cash);

            testStreet.AddHouse();
            Assert.AreEqual(200, testStreet.Rent);
            testStreet.Action(player2);
            Assert.AreEqual(2500, player2.Cash);
            Assert.AreEqual(3200, player1.Cash);

            testStreet.AddHotel();
            Assert.AreEqual(250, testStreet.Rent);
            testStreet.Action(player2);
            Assert.AreEqual(2250, player2.Cash);
            Assert.AreEqual(3400, player1.Cash);

        }
    }
}
