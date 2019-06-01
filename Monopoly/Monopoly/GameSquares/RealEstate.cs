using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class RealEstate : GameSquare
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public bool Available { get; set; }
        public bool OnMortage { get; set; }

        public RealEstate(int squareId, string name, int price) : base(squareId)
        {
            Name = name;
            Price = price;
        }
    }
}
