using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    class DrawCard: GameSquare
    {
        public override string Info
        {
            get
            {
                return "You draw a Rand card!";
            }
        }

        private IReadOnlyList<GameCard> cards;
        private Random random;

        public DrawCard(int squareId, string name, int r, int g, int b, IReadOnlyList<GameCard> cards, Random random) : base(squareId, name, r, g, b)
        {
            this.cards = cards;
            this.random = random;
        }

        public override void Action(Player player)
        {
            cards[random.Next(0, cards.Count)].CardAction(player);
        }
    }
}
