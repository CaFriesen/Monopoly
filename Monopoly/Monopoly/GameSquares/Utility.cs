using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public class Utility: RealEstate
    {
        private int baseRent;
        public override string Info
        {
            get
            {
                return "Rent " + baseRent + " * lastroll";
            }
        }

        public Utility(int squareId, int rent, int price, string name, int r, int g, int b) : base(squareId, price, name, r, g, b)
        {
            baseRent = rent;
        }

        public override void Action(Player player)
        {
            if (!Available && player != Owner && !OnMortage)
            {
                player.Cash -= baseRent * player.LastRoll;
                Owner.Cash += baseRent * player.LastRoll;
            }
        }
    }
}
