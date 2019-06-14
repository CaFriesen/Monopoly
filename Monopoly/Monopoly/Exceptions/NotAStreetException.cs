using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class NotAStreetException : Exception
    {
        public NotAStreetException(string message) : base(message)
        {

        }
    }
}
