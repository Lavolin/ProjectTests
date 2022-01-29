using Snake.Common;
using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Dot
    {
        private readonly IPositionalRenderer renderer;
        private readonly IDirection direction;
        public Dot(IPositionalRenderer renderer,IDirection direction, string symbol, Coordinate position)
        {
            this.renderer = renderer;
            this.Symbol = symbol;
            this.Position = position;
            this.direction = direction;
        }
        public Coordinate Position { get; set; }
        public string Symbol { get; set; }
       

        public void Move()
        {
            Position = direction.GetNewPosition(Position);
        }

        public void ChangeDirection(Directions direction)
        {
            this.direction.ChangeDirection(direction);
        }

        public void Render()
        {
            renderer.WriteAtPosion(Position, Symbol);
        }
    }

}
