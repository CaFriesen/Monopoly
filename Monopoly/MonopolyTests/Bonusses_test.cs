using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class Bonusses_test
    {
        [TestMethod]
        public void BonussesTest_ConstructorShouldMakeNewBonusses()
        {
            Bonusses testBonusses = new Bonusses(1,200, "Bonus", 111, 110, 100);

            Assert.AreEqual(1, testBonusses.SquareId);
            Assert.AreEqual("Bonus", testBonusses.Name);
            Assert.AreEqual(111, testBonusses.Color.R);
            Assert.AreEqual(110, testBonusses.Color.G);
            Assert.AreEqual(100, testBonusses.Color.B);
        }

        [TestMethod]
        public void BonussesTest_PlayerShouldGetBonus()
        {
            Bonusses testBonusses = new Bonusses(1, 200, "Bonus", 111, 110, 100);

            Player player = new Player();
            player.Cash = 3000;

            testBonusses.Action(player);

            Assert.AreEqual(3200, player.Cash);
        }
    }
}
