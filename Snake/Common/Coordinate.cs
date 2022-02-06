using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public Coordinate (int x, int y) // constructor
        {
            X = x;
            Y = y;
        }

        public Coordinate(Coordinate coord)
        {
            X = coord.X;
            Y = coord.Y;   
        }

        

        public int X { get; set; }

        public int Y { get; set; }


        public static Coordinate GetRandomPosition(int width, int heigth)
        {
            Random rand = new Random();
            return new Coordinate(rand.Next(0, width), rand.Next(0, heigth));
            
        }
        
        public bool Equals(Coordinate other)
        {
            if (other.X == X && other.Y == Y)
            {
                return true;
            }

            return false;
        }
    }
}
