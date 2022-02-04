using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Domain.Definitions
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Facing Facing { get; set; }

        public Position()
        {

        }
        public Position(int x, int y, Facing facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }

        public override string ToString()
        {
            return $"Rover current position ->{X} {Y} {Facing.ToString()}";
        }
    }
}
