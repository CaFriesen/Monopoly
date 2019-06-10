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
        Game Monopoly;

        public FileHandeling(Game monopoly)
        {
            Monopoly = monopoly;
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
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.txt", FileMode.Create))
            {
                formatter.Serialize(stream, Monopoly.Gameboard);
            }
        }

        public void Load()
        {

        }

        public void Export()
        {

        }
    }
}
