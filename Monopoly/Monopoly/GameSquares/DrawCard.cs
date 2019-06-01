using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameSquares
{
    class DrawCard: GameSquare
    {
        private int cardType;

        public DrawCard(int squareId, int cardType): base(squareId)
        {
            this.cardType = cardType;
        }

        public override void Action(Player player)
        {
            //Draw card based on cardType and give it to player
        }
    }
}
