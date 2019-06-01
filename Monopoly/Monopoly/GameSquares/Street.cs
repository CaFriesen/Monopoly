using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Street: RealEstate
    {
        public int Level { get; private set; }

        private int baseRent;

        public int Rent
        {
            //Add formula based on level
            get { return baseRent; }
        }

        public Street(int squareId, string name, int price, int rent): base(squareId, name, price)
        {
            baseRent = rent;
        }

        public override void Action(Player player)
        {
            throw new NotImplementedException();
        }

        public void AddHouse()
        {

        }

        public void AddHotel()
        {

        }
    }
}
