using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.src.Models
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Facing { get; set; }

        public Position(int x, int y, Direction facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }
    }

}
