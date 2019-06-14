using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;

namespace Monopoly
{
    public partial class UI : Form
    {

        private Game game;
        private List<Button> players;
        private List<Bitmap> profilePics;

        public UI()
        {
            game = new Game();
            players = new List<Button>();
            profilePics = new List<Bitmap>();

            game.PlayerTurn = 0;
            
            InitializeComponent();
            
            AddGameSquares();
            AddPlayers();
            this.Size = new Size(1050, 750);
        }

        private void AddPlayers()
        {
            
            players.Add(new Button());
            players[0].Size = new Size(12, 12);
            players[0].BackColor = Color.Blue;
            players[0].Location = BoardLocationManager.GetBoardLocation(game.Players[0].Position, game.Board.BoardSideLength, 12, 28);
            profilePics.Add(Properties.Resources.playing_tokensP1);
            
            players.Add(new Button());
            players[1].Size = new Size(12, 12);
            players[1].BackColor = Color.Red;
            players[1].Location = BoardLocationManager.GetBoardLocation(game.Players[0].Position, game.Board.BoardSideLength, 24, 28);
            profilePics.Add(Properties.Resources.playing_tokensP2);

            this.Controls.Add(players[0]);
            players[0].BringToFront();

            this.Controls.Add(players[1]);
            players[1].BringToFront();


        }

        private void AddGameSquares()
        {
          foreach(GameSquare square in game.Board.Squares)
            {
                Button property = new Button();
                property.Location = BoardLocationManager.GetBoardLocation(square.SquareId, game.Board.BoardSideLength, 0, 28);
                property.BackColor = Color.FromArgb(square.Color.R, square.Color.G, square.Color.B);
                property.Size = new Size(50, 50);
                if (square is RealEstate)
                {
                    property.Text = (square as RealEstate).Name + "\n" + (square as RealEstate).Price;
                }
                else
                {
                    property.Text = square.Name;
                }
                property.Click += (o, d) => { MessageBox.Show(square.Name + "\n" + square.Info); };
                this.Controls.Add(property);
                property.Tag = -1;
                if (square is Street)
                {
                    Label level = new Label();
                    level.Size = new Size(12, 12);
                    level.Location = BoardLocationManager.GetBoardLocation(square.SquareId, game.Board.BoardSideLength, 0, 28);
                    level.Text = (square as Street).Level.ToString();
                    level.BackColor = Color.Transparent;
                    this.Controls.Add(level);
                    level.BringToFront();
                    level.Tag = square.SquareId;
                }
            }  
        }
        
        private void btnRollP1_Click(object sender, EventArgs e)
        {
            Roll();
            GameSquare square = game.GetGameSquare(game.Players[game.PlayerTurn].Position);
            Buyable(square, game.PlayerTurn);

            panel1.BackColor = Color.FromArgb(square.Color.R, square.Color.G, square.Color.B);
            lblNamePropertyP1.Text = square.Name;
            if (square is RealEstate)
            {
                lblRentP1.Text =  (square as RealEstate).Price.ToString("C", CultureInfo.CurrentCulture);
            }
            else
            {
                lblRentP1.Text = "";
            }
        }

        private void Buyable(GameSquare square, int player)
        {
            if (square is RealEstate)
            {
                btnBuyP1.Enabled = true;
                btnP1Upgrade.Enabled = false;
                btnMortage.Enabled = false;

                if (square is Street)
                {
                    foreach (RealEstate estate in game.Players[player].RealEstates)
                    {
                        if (square == estate)
                        {
                            btnP1Upgrade.Enabled = true;
                            btnMortage.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                btnBuyP1.Enabled = false;
                btnP1Upgrade.Enabled = false;
                btnMortage.Enabled = false;
            }
        }

        private void Roll()
        {
            game.Roll();


            players[game.PlayerTurn].Location = BoardLocationManager.GetBoardLocation(game.Players[game.PlayerTurn].Position, game.Board.BoardSideLength, 12 + game.PlayerTurn * 12, 28);
            btnP1profile.Image = profilePics[game.PlayerTurn];
            btnP1profile.BackgroundImageLayout = ImageLayout.Stretch;
            lblCash.Text = "Cash: " + Convert.ToString(game.Players[game.PlayerTurn].Cash);
            lbP1Properties.DataSource = null;
            lbP1Properties.DataSource = game.Players[game.PlayerTurn].RealEstates;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Data File | *.dat";
            saveFileDialog.Title = "Save gameboard to file";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = "Board.dat";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    game.FileHandler.Save(saveFileDialog.FileName);
                }
                catch (PathTooLongException)
                {
                    MessageBox.Show("Your filename is too long");
                }
            }
        }

        private void tsLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Data File | *.dat";
            openFileDialog.Title = "Load gameboard from file";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.AddExtension = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    game.FileHandler.Load(openFileDialog.FileName);
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    MessageBox.Show("directory not found: " + dirEx.Message);
                }
                catch (FileNotFoundException fileEx)
                {
                    MessageBox.Show("file not found: " + fileEx.Message);
                }
                catch (PathTooLongException pathEx)
                {
                    MessageBox.Show("path is too long: " + pathEx.Message);
                }
                catch (SerializationException)
                {
                    MessageBox.Show("File is corrupt");
                }
            }

            AddGameSquares();
        }

        private void btnMortage_Click(object sender, EventArgs e)
        {
            game.Mortage(game.GetGameSquare(game.Players[game.PlayerTurn].Position) as RealEstate, game.Players[game.PlayerTurn]);
        }

        private void btnBuyP1_Click(object sender, EventArgs e)
        {
            try
            {
                game.Buy();
            }
            catch (NotRealEstateException ecx)
            {
                MessageBox.Show(ecx.Message);
            }
            finally
            {
                lbP1Properties.DataSource = null;
                lbP1Properties.DataSource = game.Players[game.PlayerTurn].RealEstates;
            }
        }
        
    }
}
