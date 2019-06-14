using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public class Start: ActionSquare
    {
        public override string Info
        {
            get
            {
                return "When you pass by start you get 200$";
            }
        }

        public Start(int squareId, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {
            
        }

        public override void Action(Player player)
        {
            player.Cash += 200;
        }
    }
}
