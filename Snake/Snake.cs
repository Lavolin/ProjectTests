using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public Dot Head { get; set; }

        public List<BaseDot> Body { get; set; }

        public void Render()
        {
            Head.Render();

            foreach (var dot in Body)
            {

                dot.Render();
            }
        }

        public void Move()
        {
            

            for (int i = 0; i < Body.Count - 1; i++)
            {
                Body[i].Position = new Coordinate(Body[i + 1].Position);
            }

            Body[Body.Count - 1].Position = new Coordinate(Head.Position);

            Head.Move();

            if (CheckIfDead())
            {
                throw new ArgumentException("We are dead and can't play!!!");
            }
            
        }

        public void EatFood(IPositionalRenderer renderer)
        {
            Body.Add(new BaseDot(renderer, GlobalConstants.Symbol, new Coordinate(Body[Body.Count - 1].Position)));
        }

        private bool CheckIfDead()
        {
            foreach (var dot in Body)
            {
                if (Head.Position.Equals(dot.Position))
                {
                    return true;
                }
            } 
            return false;
        }

        
    }
}
