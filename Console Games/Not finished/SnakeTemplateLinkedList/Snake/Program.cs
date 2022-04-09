using System;
using System.Threading;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = 0;
            int col = 0;
            Snake snake = new Snake();
            snake.SnakeElements.AddFirst(new Node<SnakeElement>(new SnakeElement()
            {
                Character = '@',
                Position = new Position(13,16)
            }));

            Direction direction = Direction.Up;

            while (true)
            {
                direction = ChangeDirection(direction);

                Console.Clear();

                snake.DrawSnake();
                snake.MoveSnake(direction);


                Thread.Sleep(100);
            }
        }
        public static Direction ChangeDirection(Direction direction)
        {
            if (Console.KeyAvailable)
            {
                var ch = Console.ReadKey(true).Key;
                switch (ch)
                {
                    case ConsoleKey.LeftArrow:
                        return Direction.Left;
                    case ConsoleKey.RightArrow:
                        return Direction.Right;
                    case ConsoleKey.UpArrow:
                        return Direction.Up;
                    case ConsoleKey.DownArrow:
                        return Direction.Down;
                }
            }
            return direction;
        }
    }
}
