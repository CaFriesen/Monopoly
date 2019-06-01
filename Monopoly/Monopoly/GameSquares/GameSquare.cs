using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class GameSquare : ISquareId
    {
        public int SquareId { get; private set; }

        public GameSquare(int squareId)
        {
            SquareId = squareId;
        }

        public abstract void Action(Player player);
    }
}
