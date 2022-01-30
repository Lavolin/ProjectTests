using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Common
{
    public class Direction : IDirection
    {
        private Directions direction;
        private int width;
        private int height;
        public Direction(int width, int heigth)
        {
            direction = Directions.Right;
            this.width = width;
            this.height = heigth;
        }


        public Coordinate GetNewPosition(Coordinate position)
        {
            Coordinate positionToReturn = new Coordinate(position.X, position.Y);
            switch (direction)
            {
                case Directions.Left:
                    if (positionToReturn.X <= 0)
                    {
                        ChangeDirection(Directions.Right);
                        return GetNewPosition(position);
                        
                    }
                    positionToReturn.X--;
                    break;
                case Directions.Right:
                    if (positionToReturn.X >= width - 1)
                    {
                        ChangeDirection(Directions.Left);
                        return GetNewPosition(position);
                    }
                    positionToReturn.X++;
                    break;
                case Directions.Up:
                    if (positionToReturn.Y <= 0)
                    {
                        ChangeDirection(Directions.Down);
                        return GetNewPosition(position);
                    }
                    positionToReturn.Y--;
                    break;
                case Directions.Down:
                    if (positionToReturn.Y >= height - 1)
                    {
                        ChangeDirection(Directions.Up);
                        return GetNewPosition(position);
                    }
                    positionToReturn.Y++;
                    break;
                default:
                    break;
            }
            return positionToReturn;
        }
        public void ChangeDirection(Directions direction)
        {
            this.direction = direction;
        }


    }
}
