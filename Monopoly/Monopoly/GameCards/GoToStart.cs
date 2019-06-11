using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class GoToStart : GameCard
    {
        public GoToStart(string name, string description) : base(name, description)
        {

        }

        public override void CardAction(Player player)
        {
            player.Position = 40 - player.Position;
        }
    }
}
