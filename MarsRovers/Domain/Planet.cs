using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Domain
{
    public class Planet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Planet(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
