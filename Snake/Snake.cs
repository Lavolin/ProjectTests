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
            Head.Move();

            for (int i = 0; i < Body.Count - 1; i++)
            {
                Body[i].Position.X = Body[i + 1].Position.X;
                Body[i].Position.Y = Body[i + 1].Position.Y;
            }

        }
    }
}
