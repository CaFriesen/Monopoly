using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public class GetOutOfJail : GameCard
    {
        public GetOutOfJail(string name, string description) : base(name, description)
        {

        }

        public override void CardAction(Player player)
        {
            player.HasGetOutOfJailCard = true;
        }
    }
}
