using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Monopoly
{
    public class FileHandeling
    {
        private Game Monopoly;
        private IFormatter formatter;

        public FileHandeling(Game monopoly)
        {
            Monopoly = monopoly;
            formatter = new BinaryFormatter();
        }

        public void Save()
        {
            
            using (StreamWriter w = new StreamWriter(File.Open(AppDomain.CurrentDomain.BaseDirectory + "BoardData.txt", FileMode.Create)))
            {
                foreach (GameSquare square in Monopoly.Gameboard.Squares)
                {
                    w.WriteLine(square.ToString());
                }
            }
            using (Stream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.txt", FileMode.Create))
            {
                formatter.Serialize(stream, Monopoly.Gameboard);
            }
        }

        public void Load()
        {
            using (Stream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.txt", FileMode.Open))
            {
                if (formatter.Deserialize(stream) is GameBoard)
                {
                    stream.Position = 0;
                    Monopoly.Gameboard = formatter.Deserialize(stream) as GameBoard;
                }
                else
                {
                    throw new IncorrectClassException("File is an invalid class");
                }
            }
        }

        public void Export()
        {

        }
    }
}
