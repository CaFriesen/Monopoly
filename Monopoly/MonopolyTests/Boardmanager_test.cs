using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using System.Drawing;

namespace MonopolyTests
{
    [TestClass]
    public class Boardmanager
    {
        [TestMethod]
        public void BoardLocationManagerTest_loadPoint()
        {
           Assert.AreEqual(new Point(0, 512), BoardLocationManager.GetBoardLocation(30, 10));
           Assert.AreEqual(new Point(250, 12), BoardLocationManager.GetBoardLocation(5, 10));
           Assert.AreEqual(new Point(250, 512), BoardLocationManager.GetBoardLocation(25, 10));
        }

        [TestMethod]
        public void BoardLocationManagerTest_loadPointOverloaded()
        {
            Assert.AreEqual(new Point(1, 513), BoardLocationManager.GetBoardLocation(30, 10, 1, 1));
            Assert.AreEqual(new Point(251, 13), BoardLocationManager.GetBoardLocation(5, 10, 1, 1));
            Assert.AreEqual(new Point(251, 513), BoardLocationManager.GetBoardLocation(25, 10, 1, 1));
        }


        [TestMethod]
        [ExpectedException(typeof(OffTheBoardException))]
        public void BoardLocationManagerTest_loadillegalPoint()
        {
            Point point = BoardLocationManager.GetBoardLocation(50, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(OffTheBoardException))]
        public void BoardLocationManagerTest_loadillegalPointOverloaded()
        {
            Point point = BoardLocationManager.GetBoardLocation(50, 10, 1, 1);
        }
    }
}
