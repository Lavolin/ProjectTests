using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class FoodGenerator : IFoodGenerator
    {
        private Food food;
        

        public Food GenerateFood(IPositionalRenderer renderer)
        {
            food = new Food(renderer, GlobalConstants.FoodSymbol, Coordinate.GetRandomPosition(GlobalConstants.ConsoleWidth, GlobalConstants.ConsoleHeight));  

            RenderFood();
            return this.food;
        }

        

        public void RenderFood()
        {
            food.Render();
        }
        
    }
}
