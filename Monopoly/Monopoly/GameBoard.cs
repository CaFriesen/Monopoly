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
        private List<GameCard> cards;

        public IReadOnlyList<GameSquare> Squares
        {
            get => squares;
        }

        public int BoardSideLength { get; set; }

        public GameBoard(int boardSideLength)
        {
            squares = new List<GameSquare>();
            cards = new List<GameCard>();
            BoardSideLength = boardSideLength;
            initCards();
            initMonopolyBoard();
        }

        private void initCards()
        {
            cards.Add(new Lottery("Small lottery win", "You win a small ammount of money!", 500));
            cards.Add(new Lottery("Medium lottery win", "You win a medium ammount of money!", 1000));
            cards.Add(new Lottery("Large lottery win", "You win a large ammount of money!", 2500));

            cards.Add(new SpeedingTicket("You were speeding", "Pay a fine for speeding", 400));
            cards.Add(new SpeedingTicket("You were speeding", "Pay a fine for speeding", 800));

            cards.Add(new GoToStart("Go to start", "Go to start and collect 200$"));
            cards.Add(new GetOutOfJail("You get a get out of jail card", "Next time you get jailed you can get out for free"));
        }

        private void initMonopolyBoard()
        {
            Random random = new Random();
            squares.Add(new Start(0, "Start", 0, 255, 0));
            squares.Add(new Street(1, 60, 25, 50, "Old kent road", 100, 50, 0));
            squares.Add(new DrawCard(2, "Draw card", 0, 0, 100, cards.AsReadOnly(), random));
            squares.Add(new Street(3, 60, 25, 50, "Whitechapel road", 100, 50, 0));
            squares.Add(new Taxes(4, "Income tax", 100, 0, 0));
            squares.Add(new Railroad(5, 200, 50, "Kings cross station", 100, 100, 100));
            squares.Add(new Street(6, 100, 50, 50, "The angel islington", 160, 250, 240));
            squares.Add(new DrawCard(7, "Draw card", 0, 0, 100, cards.AsReadOnly(), random));
            squares.Add(new Street(8, 100, 50, 50, "Euston road", 160, 250, 240));
            squares.Add(new Street(9, 120, 50, 50, "Pentonvile road", 160, 250, 240));

            squares.Add(new Jail(10, "Jail", 250, 170, 0));
            squares.Add(new Street(11, 140, 100, 50, "Pall mall", 200, 50, 200));
            squares.Add(new Utility(12, 75, 150, "Electric company", 250, 250, 30));
            squares.Add(new Street(13, 140, 100, 50, "Whitehall", 200, 50, 200));
            squares.Add(new Street(14, 160, 100, 50, "Marylebone station", 200, 50, 200));
            squares.Add(new Railroad(19, 200, 50, "Marylebone station", 100, 100, 100));
            squares.Add(new Street(15, 180, 200, 50, "Bow street", 250, 170, 0));
            squares.Add(new DrawCard(16, "Draw card", 0, 0, 100, cards.AsReadOnly(), random));
            squares.Add(new Street(17, 180, 200, 50, "Marlborough street", 250, 170, 0));
            squares.Add(new Street(18, 200, 200, 50, "Vine street", 250, 170, 0));

            squares.Add(new Parking(20, "Parking", 0, 0, 0));
            squares.Add(new Street(21, 220, 400, 50, "Strand", 255, 0, 0));
            squares.Add(new DrawCard(22, "Draw card", 0, 0, 100, cards.AsReadOnly(), random));
            squares.Add(new Street(23, 220, 400, 50, "Fleet street", 255, 0, 0));
            squares.Add(new Street(24, 240, 400, 50, "Trafalgar square", 255, 0, 0));
            squares.Add(new Railroad(25, 200, 50, "Fenchurch st. Station", 100, 100, 100));
            squares.Add(new Street(26, 260, 800, 50, "Leicester square", 255, 250, 30));
            squares.Add(new Street(27, 260, 800, 50, "Coventry street", 255, 250, 30));
            squares.Add(new Utility(28, 75, 150, "Water works", 250, 250, 30));
            squares.Add(new Street(29, 280, 800, 50, "Piccadilly", 255, 250, 30));

            squares.Add(new GoToJail(30, "Go to jail", 250, 170, 0));
            squares.Add(new Street(31, 300, 1600, 50, "Regent street", 0, 150, 40));
            squares.Add(new Street(32, 300, 1600, 50, "Oxford street", 0, 150, 40));
            squares.Add(new DrawCard(33, "Draw card", 0, 0, 100, cards.AsReadOnly(), random));
            squares.Add(new Street(34, 300, 1600, 50, "Bond street", 0, 150, 40));
            squares.Add(new Railroad(35, 200, 50, "Liverpool st. Station", 100, 100, 100));
            squares.Add(new DrawCard(36, "Draw card", 0, 0, 100, cards.AsReadOnly(), random));
            squares.Add(new Street(37, 350, 3200, 50, "Park lane", 0, 100, 150));
            squares.Add(new Taxes(38, "Super Tax", 100, 0, 0));
            squares.Add(new Street(39, 400, 3200, 50, "Mayfair", 0, 100, 150));
        }

        private void AddSquare(GameSquare square)
        {
            squares.Add(square);
        }
    }
}
