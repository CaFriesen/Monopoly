using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        public int Cash { get; set; }
        public int LastRoll { get; set; }
        private List<RealEstate> realEstates;

        public IReadOnlyList<RealEstate> RealEstates
        {
            get { return realEstates.AsReadOnly(); }
        }

        public Player()
        {
            realEstates = new List<RealEstate>();
        }

        public bool Buy(RealEstate estate)
        {
            return false;
        }
    }
}
