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
        public string Name { get; private set; }
        public SquareColor Color { get; private set; }
        

        public GameSquare(int squareId, string name, int r, int g, int b)
        {
            SquareId = squareId;
            Name = name;
            Color = new SquareColor(r, g, b);
        }

        public abstract void Action(Player player);
    }
}
