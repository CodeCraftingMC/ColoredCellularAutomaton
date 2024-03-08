using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredCellularAutomaton
{
    public static class IntExtensions
    {
        public static int WrapNumber(this int value, int min, int max)
        {
            int range = max - min + 1;
            return ((value - min) % range + range) % range + min;
        }

    }
}
