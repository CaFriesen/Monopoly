using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameSquares
{
    class GoToJail: ActionSquare
    {
        public GoToJail(int squareId): base(squareId)
        {
        }

        public override void Action(Player player)
        {
            player.Jailed = true;
        }
    }
}
