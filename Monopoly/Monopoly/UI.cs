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

        private Game game;
        private bool turn;
        private Button P1;
        private Button P2;

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
            P1 = new Button();
            P1.Size = new Size(12, 12);
            P1.BackColor = Color.Blue;
            P1.Location = GetBoardLocation(game.Players[0].Position, game.Gameboard.BoardSideLength, 12, 0);


            P2 = new Button();
            P2.Size = new Size(12, 12);
            P2.BackColor = Color.Red;
            P2.Location = GetBoardLocation(game.Players[0].Position, game.Gameboard.BoardSideLength, 24, 0);

            this.Controls.Add(P1);
            P1.BringToFront();

            this.Controls.Add(P2);
            P2.BringToFront();


        }

        private void AddGameSquares()
        {
          foreach(GameSquare square in game.Gameboard.Squares)
            {
                Button property = new Button();
                property.Location = GetBoardLocation(square.SquareId, game.Gameboard.BoardSideLength);
                property.ForeColor = Color.FromArgb(square.Color.R, square.Color.G, square.Color.B);
                property.Size = new Size(50, 50);
                if (square is RealEstate)
                {
                    property.Text = (square as RealEstate).Name + "\n" + (square as RealEstate).Price;
                }
                else
                {
                    property.Text = square.Name;
                }
                //property.
                //property.Click += (o, d) => { MessageBox.Show(square.Info); };
                this.Controls.Add(property);

                Label level = new Label();
                level.Size = new Size(12, 12);
                level.Location = GetBoardLocation(square.SquareId, game.Gameboard.BoardSideLength);
                level.Text = "5";
                level.BackColor = Color.Transparent;
                this.Controls.Add(level);
                level.BringToFront();
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
                case (3)://getallen boven 40 afstraffen
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

        private void Buyable(GameSquare square, int player)
        {
            if (square is RealEstate)
            {
                btnBuyP1.Enabled = true;
                btnBuyP2.Enabled = true;

                if (square is Street)
                {
                    foreach (RealEstate estate in game.Players[player].RealEstates)
                    {
                        if (square == estate)
                        {

                        }
                    }
                }
            }
            else
            {
                btnBuyP1.Enabled = false;
                btnBuyP2.Enabled = false;
            }
        }

        private void btnRollP1_Click(object sender, EventArgs e)
        {
            int player;
            
            if (turn)
            {
                player = 1;
                P1.Location = GetBoardLocation(game.Players[0].Position, game.Gameboard.BoardSideLength, 24, player);
            }
            else
            {
                player = 0;
                P2.Location = GetBoardLocation(game.Players[0].Position, game.Gameboard.BoardSideLength, 24, player);
            }

            game.Roll(player);
            Buyable(game.GetGameSquare(game.Players[0].Position), player);
            turn = !turn;
        }

        private void btnRollP2_Click(object sender, EventArgs e)
        {
            game.Roll(1);
            P2.Location = GetBoardLocation(game.Players[1].Position, game.Gameboard.BoardSideLength, 24, 0);
            Buyable(game.GetGameSquare(game.Players[1].Position), 1);
        }
    }
}
