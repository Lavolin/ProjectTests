using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Coordinate
    {
        public Coordinate (int x, int y) // constructor
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }

        public int Y { get; set; }
    }
}
