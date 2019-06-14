using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    [Serializable]
    public struct SquareColor
    {
        public readonly int R;
        public readonly int G;
        public readonly int B;

        public SquareColor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}

