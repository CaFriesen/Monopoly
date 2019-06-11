using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class IncorrectClassException : Exception
    {
        public IncorrectClassException(string message) : base(message)
        {

        }
    }
}
