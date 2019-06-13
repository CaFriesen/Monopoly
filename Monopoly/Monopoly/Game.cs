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
        public int player;


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

        public void Buy()
        {
            if (GetGameSquare(Players[player].Position) is RealEstate)
            {
                (GetGameSquare(Players[player].Position) as RealEstate).Buy(Players[player]);                
            }
            else
            {
                throw new NotRealEstateException("This square cannot be bought");
            }
        }

        public void Roll()
        {
            if (player == 0)
            {
                player = 1;
            }
            else
            {
                player = 0;
            }

            int roll = random.Next(1, 7) + random.Next(1, 7);

            if (Players[player].Jailed)
            {
                if((Players[player].LastRoll & 1) == 1 || Players[player].HasGetOutOfJailCard)
                {
                    Players[player].Jailed = false;
                    Players[player].HasGetOutOfJailCard = false;
                }
            }
            else
            {
                players[player].Position = roll;
            }
            GetGameSquare(Players[player].Position).Action(Players[player]);
            
        }

        public void Mortage()
        {
            foreach (GameSquare square in Players[player].RealEstates)
            {
                if (square == GetGameSquare(Players[player].Position) && square is RealEstate)
                {
                    (square as RealEstate).OnMortage = true;
                    Players[player].Cash += (square as RealEstate).Price / 2;
                }
            }
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
