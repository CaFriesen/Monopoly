using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Street: RealEstate
    {
        public int Level { get; private set; }

        private int baseRent;
        private int housePrice;
        private Player owner;

        public int Rent
        {
            get
            {
                if (Level == 0)
                {
                    return baseRent;
                }
                else
                {
                    return baseRent * (Level * 10);
                }
            }
        }

        public Street(int squareId, int price, int rent, int housePrice, string name, int r, int g, int b) : base(squareId, price, name, r, g, b)
        {
            baseRent = rent;
            this.housePrice = housePrice;
            Level = 0;
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
                owner.Cash += Rent;
            }
        }

        public void AddHouse()
        {
            if (Level < 4)
            {
                owner.Cash -= housePrice;
                Level++;
            }
        }

        public void AddHotel()
        {
            if (Level == 4)
            {
                owner.Cash -= housePrice;
                Level++;
            }
        }
    }
}
