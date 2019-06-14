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

        public void Save(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(stream, Monopoly.Gameboard);
            }
        }

        public void Load(string fileName)
        {
            using (Stream stream = new FileStream(fileName, FileMode.Open))
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
    }
}
