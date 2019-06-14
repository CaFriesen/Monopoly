using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class RollIsToBigException : Exception
    {
        //public string Message { get; set; }

        public RollIsToBigException(string message) : base(message)
        {
            //Message = message;
        }
    }
}
