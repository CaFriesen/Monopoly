using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game
    {
        public GameBoard Gameboard;
        private Random random;
        private List<Player> players;

        public IReadOnlyList<Player> Players
        {
            get => players;
        }
  

        public Game()
        {
            Gameboard = new GameBoard(10);
            players = new List<Player>();
            random = new Random();
            for (int i = 0; i < 2; i++)
            {
                players.Add(new Player());
            }
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
                if (square.SquareId == squareID)
                {
                    return square;
                }
            }
            throw new Exception("You're off the board (invalid Square ID)");
        }
    }
}
