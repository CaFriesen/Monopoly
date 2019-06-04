using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class GoToJail_test
    {
        [TestMethod]
        public void GoToJailTest_ConstructorShouldMakeNewGoToJail()
        {
            GoToJail testGoToJail = new GoToJail(1, "Go to jail", 111, 110, 100);

            Assert.AreEqual(1, testGoToJail.SquareId);
            Assert.AreEqual("Go to jail", testGoToJail.Name);
            Assert.AreEqual(111, testGoToJail.Color.R);
            Assert.AreEqual(110, testGoToJail.Color.G);
            Assert.AreEqual(100, testGoToJail.Color.B);
        }

        [TestMethod]
        public void GoToJailTest_PlayerShouldGetJailed()
        {
            GoToJail testGoToJail = new GoToJail(1, "Go to jail", 111, 110, 100);

            Player player = new Player();
            
            testGoToJail.Action(player);

            Assert.AreEqual(true, player.Jailed);
        }
    }
}
