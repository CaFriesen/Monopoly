using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public class Railroad: RealEstate
    {
        public override string Info
        {
            get
            {
                return "Rent: " + Rent;
            }
        }

        private int baseRent;

        public int Rent
        {
            get
            {

                if (Owner != null)
                {
                    int multiplier = 0;

                    foreach (RealEstate estate in Owner.RealEstates)
                    {
                        if (estate is Railroad)
                        {
                            multiplier++;
                        }
                    }

                    return baseRent * multiplier;
                }
                else
                {
                    return baseRent;
                }

            }
        }

        public Railroad(int squareId, int price, int rent, string name, int r, int g, int b) : base(squareId, price, name, r, g, b)
        {
            baseRent = rent;
        }

        public override void Action(Player player)
        {
            if (!Available && player != Owner && !OnMortage)
            {
                player.Cash -= Rent;
                Owner.Cash += Rent;
            }
        }
    }
}
