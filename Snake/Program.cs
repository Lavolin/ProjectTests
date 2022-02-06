using Snake.Contracts;
using Snake.IO;
using System;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = GlobalConstants.ConsoleWidth;
            Console.WindowHeight = GlobalConstants.ConsoleHeight;
            Console.BufferHeight = GlobalConstants.ConsoleHeight;
            Console.BufferWidth = GlobalConstants.ConsoleWidth;
            Console.CursorVisible = false;

            IPositionalRenderer renderer = new ConsoleRenderer();
            IReader reader = new ConsoleReader();
            IFoodGenerator generator = new FoodGenerator();

            IGameEngine gameEngine = new SnakeEngine(renderer, reader, generator);
            gameEngine.Start();

        }
    }
}
