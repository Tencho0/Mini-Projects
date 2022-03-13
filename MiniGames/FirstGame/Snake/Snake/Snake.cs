using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake
    {
        public Dot Head { get; set; }
        public List<BaseDot> Body { get; set; }

        public void Render()
        {
            foreach (var dot in this.Body)
            {
                dot.Render();
            }
        }

    }
}
