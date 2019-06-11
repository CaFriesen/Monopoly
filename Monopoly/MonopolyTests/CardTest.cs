using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardTest_SpeedingTicketShouldRemoveMoney()
        {
            SpeedingTicket card = new SpeedingTicket("Name", "Description", 10);
            Player player = new Player();
            player.Cash = 2000;

            card.CardAction(player);
            Assert.AreEqual(1990, player.Cash);
        }

        [TestMethod]
        public void CardTest_LotteryShouldAddMoney()
        {
            Lottery card = new Lottery("Name", "Description", 100);
            Player player = new Player();
            player.Cash = 2000;

            card.CardAction(player);
            Assert.AreEqual(2100, player.Cash);
        }

        [TestMethod]
        public void CardTest_MoveToStart()
        {
            GoToStart card = new GoToStart("Name", "Description");
            Player player = new Player();
            player.Position = 12;

            card.CardAction(player);

            Assert.AreEqual(0, player.Position);
        }

        [TestMethod]
        public void CardTest_GetGetOutOfJailCard()
        {
            GetOutOfJail card = new GetOutOfJail("Name", "Description");
            Player player = new Player();

            card.CardAction(player);

            Assert.AreEqual(true, player.HasGetOutOfJailCard);
        }
    }
}
