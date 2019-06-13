using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Monopoly
{
    public static class BoardLocationManager
    {

        /// <summary>
        /// 
        /// contains a array of size 2 wich contains a board size and length
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="boardSize"></param>
        /// <returns></returns>
        public static Point GetBoardLocation(int orderNumber, int boardSideLength)
        {
            Point loc = new Point();
            switch (orderNumber / boardSideLength)
            {
                case (3):
                    loc.X = 0;
                    loc.Y = ((boardSideLength * 50) + 12) - (orderNumber - (boardSideLength * 3)) * 50;
                    break;
                case (2):
                    loc.X = (boardSideLength * 50) - (orderNumber - (boardSideLength * 2)) * 50;
                    loc.Y = ((boardSideLength * 50) + 12);
                    break;
                case (1):
                    loc.X = 50 * boardSideLength;
                    loc.Y = 12 + ((orderNumber - boardSideLength) * 50);
                    break;
                case (0):
                    loc.X = (orderNumber * 50);
                    loc.Y = 12;
                    break;
                default:
                    break;
            }
            return loc;
        }

        public static Point GetBoardLocation(int orderNumber, int boardSideLength, int offsetX, int offsetY)
        {
            Point loc = new Point();
            switch (orderNumber / boardSideLength)
            {
                case (3):
                    loc.X = 0 + offsetX;
                    loc.Y = ((boardSideLength * 50) + 12) - (orderNumber - (boardSideLength * 3)) * 50 + offsetY;
                    break;
                case (2):
                    loc.X = (boardSideLength * 50) - (orderNumber - (boardSideLength * 2)) * 50 + offsetX;
                    loc.Y = ((boardSideLength * 50) + 12) + offsetY;
                    break;
                case (1):
                    loc.X = 50 * boardSideLength + offsetX;
                    loc.Y = 12 + ((orderNumber - boardSideLength) * 50) + offsetY;
                    break;
                case (0):
                    loc.X = (orderNumber * 50) + offsetX;
                    loc.Y = 12 + offsetY;
                    break;
                default:
                    break;
            }
            return loc;
        }
    }
}
