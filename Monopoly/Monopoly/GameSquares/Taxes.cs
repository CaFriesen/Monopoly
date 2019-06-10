using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public class Taxes: ActionSquare
    {
        public Taxes(int squareId, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {
        }

        public override void Action(Player player)
        {
            int totalWorth = 0;

            foreach (RealEstate estate in player.RealEstates)
            {
                totalWorth += estate.Price;
                if (estate is Street)
                {
                    totalWorth += (estate as Street).Level * (estate as Street).HousePrice;
                }
            }

            if ((totalWorth / 100) * 10 > 200)
            {
                player.Cash -= (totalWorth / 100) * 10;
            }
            else
            {
                player.Cash -= 200;
            }
        }
    }
}
