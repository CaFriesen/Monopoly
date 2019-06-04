using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Taxes: ActionSquare
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
                    totalWorth+= (estate as Street).Level * 50;
                }
            }

            player.Cash -= totalWorth;
            //Get tax from player either 10% of all assets or 200$
        }
    }
}
