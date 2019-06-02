using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game
    {
        private GameBoard Gameboard;
        private Random random;
        private List<GameSquare> squares;
        private Player[] players;
        private Player player1;
        private Player player2;

        public IReadOnlyList<GameSquare> Squares
        {
            get => squares;
        }

        public Game()
        {
            Gameboard = new GameBoard();
            players = { new Player(), new Player()}; //TODO make player array working
            random = new Random();
        }

        public int Roll(int xPlayer)
        {
            Player player = players[xPlayer];
            player.Position = random.Next(1, 7) + random.Next(1, 7);
            return player.Position;
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
