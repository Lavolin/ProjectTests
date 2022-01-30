using Snake.Common;
using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeEngine : IGameEngine
    {
        private readonly IPositionalRenderer renderer;
        private readonly IReader reader;
        private Dot dot;

        public SnakeEngine(IPositionalRenderer renderer, IReader reader)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.dot = new Dot(renderer, new Direction(
                GlobalConstants.ConsoleWidth, 
                GlobalConstants.ConsoleHeight), 
                GlobalConstants.Symbol, GlobalConstants.Center);
        }

        public void Start()
        {
            while (true)
            {
                ChangeDirection();
                dot.Move();
                dot.Render();
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private void ChangeDirection()
        {
            string keyPressed = reader.ReadKey();
            if (keyPressed != null)
            {

                switch (keyPressed)
                {
                    case "LeftArrow":
                        dot.ChangeDirection(Directions.Left);
                        break;
                    case "RightArrow":
                        dot.ChangeDirection(Directions.Right);
                        break;
                    case "UpArrow":
                        dot.ChangeDirection(Directions.Up);
                        break;
                    case "DownArrow":
                        dot.ChangeDirection(Directions.Down);
                        break;
                    default:
                        break;
                }

            }
        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}
