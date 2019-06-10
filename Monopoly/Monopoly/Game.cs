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
        public FileHandeling fileHandler;
        private Random random;
        private List<Player> players;


        public IReadOnlyList<Player> Players
        {
            get => players;
        }
  

        public Game()
        {
            Gameboard = new GameBoard(10);
            fileHandler = new FileHandeling(this);
            players = new List<Player>();
            random = new Random();
            for (int i = 0; i < 2; i++)
            {
                players.Add(new Player());
            }
            fileHandler.Save();
            fileHandler.Load();
        }

        public int Roll(int xPlayer)
        {
            players[xPlayer].Position = random.Next(1, 7) + random.Next(1, 7);
            return players[xPlayer].Position;
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
