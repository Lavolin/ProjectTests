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
        public Direction()
        {
            direction = Directions.Right;
        }


        public Coordinate GetNewPosition(Coordinate position)
        {
            Coordinate positionToReturn = new Coordinate(position.X, position.Y);
            switch (direction)
            {
                case Directions.Left:
                    positionToReturn.X--;
                    break;
                case Directions.Right:
                    positionToReturn.X++;
                    break;
                case Directions.Up:
                    positionToReturn.Y--;
                    break;
                case Directions.Down:
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
