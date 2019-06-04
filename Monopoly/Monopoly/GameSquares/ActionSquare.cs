using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class ActionSquare: GameSquare
    {
        public ActionSquare(int squareId, string name, int r, int g, int b): base(squareId, name, r, g, b)
        {
        }
    }
}
