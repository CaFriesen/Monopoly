using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameCards
{
    public abstract class GameCard
    {
        public GameCard()
        {

        }

        public abstract void CardAction(Player player);
    }
}
