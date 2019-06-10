using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public class GameBoard
    {
        private List<GameSquare> squares;

        public IReadOnlyList<GameSquare> Squares
        {
            get => squares;
        }

        public int BoardSideLength { get; set; }

        public GameBoard(int boardSideLength)
        {
            squares = new List<GameSquare>();
            BoardSideLength = boardSideLength;
            initMonopolyBoard();
        }

        private void initMonopolyBoard()
        {
            for (int i = 0; i < 40; i++)
            {
                squares.Add(new Taxes(i, "West", 0, 200, 0));
            }
        }
        private void AddSquare(GameSquare square)
        {
            squares.Add(square);
        }
    }
}
