using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ConsoleRenderer : IPossitionRender
    {
        public void WritePossition(Coordinate coordinate, object input)
        {
            Console.SetCursorPosition(coordinate.X, coordinate.Y);
            Console.Write(input);
        }
    }
}
