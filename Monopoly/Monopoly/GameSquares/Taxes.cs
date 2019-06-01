using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Taxes: ActionSquares
    {
        public Taxes(int squareId): base(squareId)
        {
        }

        public override void Action(Player player)
        {
            //Get tax from player either 10% of all assets or 200$
        }
    }
}
