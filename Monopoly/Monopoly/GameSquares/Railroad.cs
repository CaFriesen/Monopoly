using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Railroad: RealEstate
    {
        private int baseRent;
        private Player owner;

        public int Rent
        {
            get
            {
                int multiplier = 0;

                foreach (RealEstate estate in owner.RealEstates)
                {
                    if (estate is Railroad)
                    {
                        multiplier++;
                    }
                }

                return baseRent * multiplier;
            }
        }

        public Railroad(int squareId, string name, int price, int rent): base(squareId, name, price)
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
                player.Cash -= Rent;
            }
        }
    }
}
