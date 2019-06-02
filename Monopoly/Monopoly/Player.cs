using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
