using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Utility: RealEstate
    {
        private int baseRent;
        private Player owner;

        public Utility(int squareId, int rent, int price, string name, int r, int g, int b) : base(squareId, price, name, r, g, b)
        {
            baseRent = rent;
        }

        public override void Action(Player player)
        {
            if (Available)
            {
                if (player.Buy(this))
                {
                    owner = player;
                }
            }
            else
            {
                player.Cash -= baseRent * player.LastRoll;
            }
        }
    }
}
