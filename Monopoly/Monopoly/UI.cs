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
    public partial class UI : Form
    {
        //TODO change UI to UI 

        private Game game;

        public UI()
        {
            InitializeComponent();
            game = new Game();
            AddGameSquares();
            AddPlayers();
            this.Size = new Size(1050, 750);

        }

        private void AddPlayers()
        {

        }

        private void AddGameSquares()
        {
          foreach(GameSquare square in game.Gameboard.Squares)
            {
                Button property = new Button();
                Label level = new Label();
                property.Location = GetBoardLocation(square.SquareId, 10);
                level.Location = GetBoardLocation(square.SquareId, 10, 25, 0);
                level.Text = "5";
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
                //property.Click += (o, d) => { MessageBox.Show(square.Info); };
                this.Controls.Add(property);
                this.Controls.Add(level);
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
                    loc.Y = ((boardSideLength * 50) + 12) - (orderNumber - (boardSideLength * 3)) * 50;
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
                    loc.X = (orderNumber * 50); 
                    loc.Y = 12;
                    break;
                default:
                    break;
            }
            return loc;
        }

        private Point GetBoardLocation(int orderNumber, int boardSideLength, int offsetX, int offsetY)
        {
            Point loc = new Point();
            switch (orderNumber / boardSideLength)
            {
                case (3):
                    loc.X = 0 + offsetX;
                    loc.Y = ((boardSideLength * 50) + 12) - (orderNumber - (boardSideLength * 3)) * 50 + offsetY;
                    break;
                case (2):
                    loc.X = (boardSideLength * 50) - (orderNumber - (boardSideLength * 2)) * 50 + offsetX;
                    loc.Y = ((boardSideLength * 50) + 12) + offsetY;
                    break;
                case (1):
                    loc.X = 50 * boardSideLength + offsetX;
                    loc.Y = 12 + ((orderNumber - boardSideLength) * 50) + offsetY;
                    break;
                case (0):
                    loc.X = (orderNumber * 50) + offsetX;
                    loc.Y = 12 + offsetY;
                    break;
                default:
                    break;
            }
            return loc;
        }

        private void btnRollP1_Click(object sender, EventArgs e)
        {
            game.Roll(0);

        }
    }
}
