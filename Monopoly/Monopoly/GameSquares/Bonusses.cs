using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public class Bonusses: ActionSquare
    {
        private int bonusAmmount;
        public Bonusses(int squareId, int bonus, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {
            bonusAmmount = bonus;
        }

        public override void Action(Player player)
        {
            player.Cash += bonusAmmount;
        }
    }
}
