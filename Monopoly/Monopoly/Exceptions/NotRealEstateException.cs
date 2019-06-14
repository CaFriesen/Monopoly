using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class NotRealEstateException : Exception
    {
        public NotRealEstateException(string message) : base(message)
        {

        }
    }
}
