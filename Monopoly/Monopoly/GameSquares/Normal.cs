using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public abstract class Normal: GameSquare
    {
        public Normal(int squareId, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {
            
        }
    }
}
