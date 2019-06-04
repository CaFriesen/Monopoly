using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly
{
    public partial class Monopoly : Form
    {
        //TODO change Monopoly to UI 

        private Game game;

        public Monopoly()
        {
            InitializeComponent();
            game = new Game();
            AddGameSquares();
        }

        private void AddGameSquares()
        {
          foreach(GameSquare square in game.Gameboard.Squares)
            {
                Button property = new Button();
                property.Location = GetBoardLocation(square.SquareId, 10); //GameBoard toevoegen aan UI?
                property.ForeColor = Color.FromArgb(square.Color.R, square.Color.G, square.Color.B);
                property.Size = new Size(50, 50);
                if(square is RealEstate)
                {
                    property.Text = (square as RealEstate).Name + "\n" + (square as RealEstate).Price;
                }
                else
                {
                    property.Text = square.Name;
                }
                this.Controls.Add(property);
            }  
        }
        /// <summary>
        /// 
        /// contains a array of size 2 wich contains a board size and length
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="boardSize"></param>
        /// <returns></returns>
        private Point GetBoardLocation(int orderNumber, int boardSideLength)
        {
            Point loc = new Point();
            switch (orderNumber / boardSideLength)
            {
                case (3):
                   loc.X = 0;
                    loc.Y = ((boardSideLength * 50) + 12) - (orderNumber - (boardSideLength * 3)) * 50;//TODO vind uit waard de locaties op een form liggen
                    break;
                case (2):
                    loc.X = (boardSideLength * 50) - (orderNumber - (boardSideLength * 2)) * 50;
                    loc.Y = ((boardSideLength * 50) + 12);
                    break;
                case (1):
                    loc.X = 50 * boardSideLength;
                    loc.Y = 12 + ((orderNumber - boardSideLength) * 50);
                    break;
                case (0):
                    loc.X = (orderNumber * 50); //standaard waarden
                    loc.Y = 12;
                    break;
                default:
                    break;
            }
            return loc;
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {

        }
    }
}
