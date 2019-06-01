using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameSquares
{
    class Start: ActionSquares
    {
        public Start(int squareId): base(squareId)
        {
            
        }

        public override void Action(Player player)
        {
            //Give player 200$
        }
    }
}
