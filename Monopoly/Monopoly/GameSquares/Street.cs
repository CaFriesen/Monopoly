using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Street: RealEstate
    {
        private int baseRent;
        public int HousePrice { get; private set; }

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
                    return baseRent * (Level * 2);
                }
            }
        }
        public int Level { get; private set; }

        public Street(int squareId, int price, int rent, int housePrice, string name, int r, int g, int b) : base(squareId, price, name, r, g, b)
        {
            baseRent = rent;
            HousePrice = housePrice;
            Level = 0;
        }

        public override void Action(Player player)
        {
            if (!Available && player != Owner)
            {
                player.Cash -= Rent;
                Owner.Cash += Rent;
            }
        }

        public void AddHouse()
        {
            if (Level < 4 && Owner != null)
            {
                Owner.Cash -= HousePrice;
                Level++;
            }
        }

        public void AddHotel()
        {
            if (Level == 4 && Owner != null)
            {
                Owner.Cash -= HousePrice;
                Level++;
            }
        }
    }
}
