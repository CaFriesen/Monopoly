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

        public Utility(int squareId, string name, int price, int rent): base(squareId, name, rent)
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
