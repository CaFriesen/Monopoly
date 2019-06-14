using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerTest_ConstructorShouldMakeNewPlayer()
        {
            Player player = new Player();

            Assert.AreEqual(1500, player.Cash);
            Assert.AreEqual(0, player.Position);
            Assert.AreEqual(0, player.RealEstates.Count);
            Assert.AreEqual(0, player.RealEstates.Count);

        }

        [TestMethod]
        public void PlayerTest_AddRealestateShouldAddRealEstate()
        {
            Street testStreet = new Street(1, 100, 25, 50, "testStreet", 111, 110, 100);
            Player player = new Player();

            Assert.AreEqual(0, player.RealEstates.Count);

            player.AddRealEstate(testStreet);

            Assert.AreEqual(testStreet, player.RealEstates[0]);
            
        }
    }
}
