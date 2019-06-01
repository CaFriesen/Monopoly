using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Bonusses: ActionSquares
    {
        private int bonusAmmount;
        public Bonusses(int squareId, int bonus): base(squareId)
        {
            bonusAmmount = bonus;
        }

        public override void Action(Player player)
        {
            //Give player bonus based on bonusammount
        }
    }
}
