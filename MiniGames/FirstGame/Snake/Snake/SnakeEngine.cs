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
    class SnakeEngine : IGameEngine
    {
        private readonly IPossitionRender renderer;
        private readonly IReader reader;
        private Snake snake;
        public SnakeEngine(IPossitionRender renderer, IReader reader)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.snake = SnakeFactory.CreateSnake(renderer); 
        }
        public void Start()
        {
            while (true)
            {
              //  ChangeDirection();
                this.snake.Render();
                Thread.Sleep(100);
                Console.Clear();
            }
        }
        public void Terminate()
        {
            throw new NotImplementedException();
        }
        //private void ChangeDirection()
        //{
        //    string keyPressed = reader.ReadKey();
        //    if (keyPressed != "null")
        //    {
        //        switch (keyPressed)
        //        {
        //            case "LeftArrow":
        //                dot.ChangeDirection(Directions.Left);
        //                break;
        //            case "RightArrow":
        //                dot.ChangeDirection(Directions.Right);
        //                break;
        //            case "DownArrow":
        //                dot.ChangeDirection(Directions.Down);
        //                break;
        //            case "UpArrow":
        //                dot.ChangeDirection(Directions.Up);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
