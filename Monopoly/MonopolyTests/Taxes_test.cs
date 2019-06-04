using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class Taxes_test
    {
        [TestMethod]
        public void TaxesTest_ConstructorShouldMakeNewTaxes()
        {
            Taxes testTaxes = new Taxes(1, "Tax", 111, 110, 100);

            Assert.AreEqual(1, testTaxes.SquareId);
            Assert.AreEqual("Tax", testTaxes.Name);
            Assert.AreEqual(111, testTaxes.Color.R);
            Assert.AreEqual(110, testTaxes.Color.G);
            Assert.AreEqual(100, testTaxes.Color.B);
        }

        [TestMethod]
        public void TaxesTest_PlayerShouldPayTaxes()
        {
            Taxes testTaxes = new Taxes(1, "Tax", 111, 110, 100);

            Player player = new Player();
            player.Cash = 3000;

            testTaxes.Action(player);

            Assert.AreEqual(2800, player.Cash);
        }

        [TestMethod]
        public void TaxesTest_PlayerShouldPayMoreTaxesIfTheyOwnMoreEstates()
        {
            Street testStreet1 = new Street(1, 1000, 50, 50, "test", 111, 110, 100);
            Street testStreet2 = new Street(2, 1000, 50, 50, "test", 111, 110, 100);
            Street testStreet3 = new Street(3, 1000, 50, 50, "test", 111, 110, 100);
            Street testStreet4 = new Street(4, 1000, 50, 50, "test", 111, 110, 100);

            Taxes testTaxes = new Taxes(1, "Tax", 111, 110, 100);

            Player player = new Player();
            player.Cash = 9000;

            testStreet1.Buy(player);
            testStreet2.Buy(player);
            testStreet3.Buy(player);
            testStreet4.Buy(player);

            testStreet2.AddHouse();
            testStreet2.AddHouse();

            testStreet3.AddHouse();
            testStreet3.AddHouse();
            testStreet3.AddHouse();
            testStreet3.AddHouse();
            testStreet3.AddHotel();
                                    

            testTaxes.Action(player);

            Assert.AreEqual(4220, player.Cash);
        }

    }
}
