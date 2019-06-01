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

        public Railroad(int squareId, string name, int price, int rent): base(squareId, name, price)
        {
            baseRent = rent;
        }

        public override void Action(Player player)
        {
            //If not owned try to sell to player
            //Else
            //Take rent based on baseRent and other owned stations if player is not owner
        }
    }
}
