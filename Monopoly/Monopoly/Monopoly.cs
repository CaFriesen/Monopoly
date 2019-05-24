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
                property.Location = GetGameSquareLocation(square.ID, /*hoe kunnnen we een array uit gameboard hier het best halen?*/);
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

        private Point GetGameSquareLocation(int orderNumber, int[] boardSize)
        {
            Point loc = new Point();
            switch (orderNumber / (boardSize[1] / 4))
            {
                case (3):
                   loc.X = orderNumber - (boardSize[0] * 3);
                    loc.Y = 32;//TODO vind uit waard de locaties op een form liggen
                    break;
                case (2):
                    loc.X = 9 //Standaard waarden
                    loc.Y = orderNumber - (boardSize[0] * 2);
                    break;
                case (1):
                    loc.X = orderNumber - (boardSize[0]);
                    loc.Y = 0;//standaard
                    break;
                case (0):
                    loc.X = 0; //standaard waarden
                    loc.Y = orderNumber;
                    break;
                case default: //uitzoeken waarom dit niet mag
                    break;
            }
            return loc;
        }
    }
}
