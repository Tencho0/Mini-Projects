using Snake.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Contracts
{
   public interface IDirection
    {
        Coordinate GetNewPossition(Coordinate possition);
        void ChangeDirection(Directions direction);
    }
}
