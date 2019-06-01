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

        public Utility(int squareId, string name, int price, int rent): base(squareId, name, rent)
        {
            baseRent = rent;
        }

        public override void Action(Player player)
        {
            //Attempt to sell if unsold
            //Else
            //Get rent from player based on owned utilitys and the dice player rolled
        }
    }
}
