using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameSquares
{
    [Serializable]
    class DrawCard: GameSquare
    {

        public DrawCard(int squareId, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {

        }

        public override void Action(Player player)
        {
            //Draw card based on cardType and give it to player
        }
    }
}
