using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    class Parking: Normal
    {
        public override string Info
        {
            get
            {
                return "Park your car!";
            }
        }
        public Parking(int squareId, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {
            
        }

        public override void Action(Player player)
        {
        }
    }
}
