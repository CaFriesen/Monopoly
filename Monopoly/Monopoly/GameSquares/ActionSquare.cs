using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class ActionSquare: GameSquare
    {
        public ActionSquare(int squareId): base(squareId)
        {
        }
    }
}
