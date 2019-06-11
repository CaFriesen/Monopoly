using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class SpeedingTicket : GameCard
    {
        public int Ammount { get; private set; }
        public SpeedingTicket(string name, string description, int ammount) : base(name, description)
        {
            Ammount = ammount;
        }

        public override void CardAction(Player player)
        {
            player.Cash -= Ammount;
        }
    }
}
