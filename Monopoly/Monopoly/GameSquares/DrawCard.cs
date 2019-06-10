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
        private int cardType;

        public DrawCard(int squareId, int cardType, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {
            this.cardType = cardType;
        }

        public override void Action(Player player)
        {
            //Draw card based on cardType and give it to player
        }
    }
}
