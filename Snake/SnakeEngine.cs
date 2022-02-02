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
        private Snake snake;

        public SnakeEngine(IPositionalRenderer renderer, IReader reader)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.snake = SnakeFactory.CreateSnake(renderer);
            this.snake.Body.Reverse();
        }

        public void Start()
        {
            while (true)
            {
                changedirection();
                this.snake.Render();
                this.snake.Move();
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private void changedirection()
        {
            string keypressed = reader.ReadKey();
            if (keypressed != null)
            {

                switch (keypressed)
                {
                    case "leftarrow":
                        snake.Head.ChangeDirection(Directions.Left);
                        break;
                    case "rightarrow":
                        snake.Head.ChangeDirection(Directions.Right);
                        break;
                    case "uparrow":
                        snake.Head.ChangeDirection(Directions.Up);
                        break;
                    case "downarrow":
                        snake.Head.ChangeDirection(Directions.Down);
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
