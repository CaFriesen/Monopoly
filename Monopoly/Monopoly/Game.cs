using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game
    {
        GameBoard Gameboard;

        public Game()
        {
            Gameboard = new GameBoard();
        }

        public GameSquare GetGameSquare(int squareID)
        {
            foreach (GameSquare square in Gameboard.Squares)
            {
                if (square.ID == squareID)
                {
                    return square;
                }
            }
            throw new Exception("You're off the board (invalid Square ID)");
        }
    }
}
