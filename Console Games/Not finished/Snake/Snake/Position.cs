using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Position
    {
        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public Position(Position position)
        {
            Row = position.Row;
            Col = position.Col;
        }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
