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
        public int Position
        {
            get { return Position }

            set
            {
                int newPosition = Position + value;
                if (newPosition >= 40 && newPosition <= 80)
                {
                    Position = newPosition - 40;
                }
                else
                {
                    if(newPosition >= 80)
                    {
                        throw new Exception(RollIsToBigException); //whoopsie daisy
                    }
                    else
                    {
                        Position = newPosition;
                    }
                }
            }
        }

        public Player(int startPosistion)
        {
            Position = startPosistion;
        }
        public int Cash { get; set; }
        public bool Jailed { get; set; }
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
