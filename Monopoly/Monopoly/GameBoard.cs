using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class GameBoard
    {
        private List<GameSquare> squares;

        public IReadOnlyList<GameSquare> Squares
        {
            get => squares;
        }

        public GameBoard()
        {
            squares = new List<GameSquare>();
        }

        public void AddSquare(GameSquare square)
        {
            squares.Add(square);
        }
    }
}
