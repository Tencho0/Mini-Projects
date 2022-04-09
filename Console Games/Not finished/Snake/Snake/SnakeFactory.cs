using Snake.Common;
using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeFactory
    {
        public static Snake CreateSnake(IPossitionRender renderer)
        {
            var snake = new Snake();
            snake.Head = CreateSnakeHead(renderer);
            snake.Body = CreateSnakeBody(renderer, snake.Head);
            return snake;
        }
        private static List<BaseDot> CreateSnakeBody(IPossitionRender renderer, Dot head)
        {
            var body = new List<BaseDot>();
            for (int i = 0; i < GlobalConstants.InitialSnakeBodySize; i++)
            {
                var possition = new Coordinate(head.Possition.X - i - 1, head.Possition.Y);
                var bodyDot = new BaseDot(renderer, GlobalConstants.Symbol, possition);
                body.Add(bodyDot);
            }
            return body;
        }
        private static Dot CreateSnakeHead(IPossitionRender renderer)
        {
            return new Dot(renderer, new Direction(GlobalConstants.ConsoleWidth, GlobalConstants.ConsoleHeight), GlobalConstants.Symbol, GlobalConstants.Center);
        }
    }
}
