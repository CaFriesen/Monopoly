using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameSquares
{
    class OffTheBoardException : Exception
    {
        public OffTheBoardException(string message) : base(message)
        {

        }
    }
}
