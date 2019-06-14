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
        public int player = 0;


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
                Jailed();
            }
            else
            {
                players[player].Position = roll;
            }
            GetGameSquare(Players[player].Position).Action(Players[player]);
            
        }

        private void Jailed()
        {
            if (Players[player].Position != Gameboard.JailLocation)
            {
                Players[player].Position = Gameboard.BoardSideLength * 4 - Players[player].Position + Gameboard.JailLocation;
            }
            if ((Players[player].LastRoll % 2 == 0 || Players[player].HasGetOutOfJailCard))
            {
                Players[player].Jailed = false;
                Players[player].HasGetOutOfJailCard = false;
                Players[player].Position = Players[player].LastRoll;
            }
        }

        public void Mortage(RealEstate estate, Player player)
        {
            if (estate == null)
            {
                throw new ArgumentNullException("estate is null");
            }
            estate.OnMortage = true;
                    player.Cash += estate.Price;
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
            throw new OffTheBoardException("You're off the board (invalid Square ID)");
        }
    }
}
