using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game
    {
        public GameBoard Board;
        public FileHandeling FileHandler;
        private Random Rand;
        private List<Player> players;
        public int PlayerTurn { get; set; }


        public IReadOnlyList<Player> Players
        {
            get => players;
        }
  

        public Game()
        {
            Board = new GameBoard(10);
            FileHandler = new FileHandeling(this);
            players = new List<Player>();
            Rand = new Random();
            PlayerTurn = 0;
            for (int i = 0; i < 2; i++)
            {
                players.Add(new Player());
            }
        }

        public void Buy()
        {
            if (GetGameSquare(Players[PlayerTurn].Position) is RealEstate)
            {
                (GetGameSquare(Players[PlayerTurn].Position) as RealEstate).Buy(Players[PlayerTurn]);                
            }
            else
            {
                throw new NotRealEstateException("This square cannot be bought");
            }
        }

        public void Roll()
        {
            if (PlayerTurn == 0)
            {
                PlayerTurn = 1;
            }
            else
            {
                PlayerTurn = 0;
            }

            int roll = Rand.Next(1, 7) + Rand.Next(1, 7);

            if (Players[PlayerTurn].Jailed)
            {
                Jailed();
            }
            else
            {
                players[PlayerTurn].Position = roll;
            }
            GetGameSquare(Players[PlayerTurn].Position).Action(Players[PlayerTurn]);
            
        }

        private void Jailed()
        {
            if (Players[PlayerTurn].Position != Board.JailLocation)
            {
                Players[PlayerTurn].Position = Board.BoardSideLength * 4 - Players[PlayerTurn].Position + Board.JailLocation;
            }
            if ((Players[PlayerTurn].LastRoll % 2 == 0 || Players[PlayerTurn].HasGetOutOfJailCard))
            {
                Players[PlayerTurn].Jailed = false;
                Players[PlayerTurn].HasGetOutOfJailCard = false;
                Players[PlayerTurn].Position = Players[PlayerTurn].LastRoll;
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
            foreach (GameSquare square in Board.Squares)
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
