using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.PropertyGridInternal;

namespace Monopoly
{
    [Serializable]
    public abstract class RealEstate : GameSquare
    {
        public int Price { get; private set; }
        public bool Available { get; set; }
        public bool OnMortage { get; set; }

        public Player Owner { get; private set; }

        public RealEstate(int squareId, int price, string name, int r, int g, int b) : base(squareId, name, r, g, b)
        {
            Price = price;
            Available = true;
            OnMortage = false;
        }
        
        public void Buy(Player player)
        {
            if (Available)
            {
                player.Cash -= Price;
                Owner = player;
                player.AddRealEstate(this);
                Available = false;
            }
        }
    }
}
