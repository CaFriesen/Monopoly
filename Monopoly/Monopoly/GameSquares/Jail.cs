using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    class Jail: Normal
    {
        public override string Info
        {
            get
            {
                return "This is the jail i hope you aren't stuck here";
            }
        }

        public Jail(int squareId, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {
            
        }

        public override void Action(Player player)
        {
            
        }
    }
}
