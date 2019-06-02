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
        }

        private void AddGameSquares()
        {
          foreach(GameSquare square in game.Squares)
            {
                Button property = new Button();
                property.Location = GetBoardLocation(square.ID, 10); //GameBoard toevoegen aan UI?
                property.ForeColor = square.Color;
                if(square is RealEstate)
                {
                    property.Text = square.Name + "\n" + square.Price;
                }
                else
                {
                    property.Text = square.Name;
                }
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
                   loc.X = 450;
                    loc.Y = ((boardSideLength * 75) + 12) - (orderNumber - (boardSideLength * 3)) * 75;//TODO vind uit waard de locaties op een form liggen
                    break;
                case (2):
                    loc.X = ((boardSideLength * 75) + 450) - (orderNumber - (boardSideLength * 2)) * 75;
                    loc.Y = ((boardSideLength * 75) + 12);
                    break;
                case (1):
                    loc.X = 450 + 75 * boardSideLength;
                    loc.Y = 12 + ((orderNumber - boardSideLength) * 75);
                    break;
                case (0):
                    loc.X = (orderNumber * 75) + 12; //standaard waarden
                    loc.Y = 450;
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
