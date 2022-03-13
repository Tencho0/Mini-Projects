using Snake.Common;
using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Dot : BaseDot
    {
        private readonly IDirection direction;
        public Dot(IPossitionRender renderer, IDirection direction, string symbol, Coordinate possition)
            : base(renderer, symbol, possition)
        {
            this.direction = direction;
        }
        public void ChangeDirection (Directions direction)
        {
            this.direction.ChangeDirection(direction);
        }
        public void Move()
        {
            this.Possition = this.direction.GetNewPossition(this.Possition);
        }
    }
}
