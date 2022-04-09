using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Common
{
    public class Direction : IDirection
    {
        private Directions direction;
        private int width;
        private int height;
        public Direction(int width, int height)
        {
            direction = Directions.Right;
            this.width = width;
            this.height = height;
        }

        public Coordinate GetNewPossition(Coordinate possition)
        {
            Coordinate possitionToReturn = new Coordinate(possition.X, possition.Y);
            switch (direction)
            {
                case Directions.Left:
                    if (possitionToReturn.X <= 0)
                    {
                        this.ChangeDirection(Directions.Right);
                        return this.GetNewPossition(possition);
                    }
                    possitionToReturn.X--;
                    break;
                case Directions.Right:
                    if (possitionToReturn.X >= width - 1)
                    {
                        this.ChangeDirection(Directions.Left);
                        return this.GetNewPossition(possition);
                    }
                    possitionToReturn.X++;
                    break;
                case Directions.Up:
                    if (possitionToReturn.Y <= 0)
                    {
                        this.ChangeDirection(Directions.Down);
                        return this.GetNewPossition(possition);
                    }
                    possitionToReturn.Y--;
                    break;
                case Directions.Down:
                    if (possitionToReturn.Y >= height - 1)
                    {
                        this.ChangeDirection(Directions.Up);
                        return this.GetNewPossition(possition);
                    }
                    possitionToReturn.Y++;
                    break;
                default:
                    break;
            }
            return possitionToReturn;
        }
         
        public void ChangeDirection(Directions direction)
        {
            this.direction = direction;
        }
    }
}