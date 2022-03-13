using Snake.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class BaseDot
    {
        private readonly IPossitionRender renderer;
        public BaseDot(IPossitionRender renderer, string symbol, Coordinate possition)
        {
            this.Renderer = renderer;
            this.Symbol = symbol;
            this.Possition = possition;
        }
        public IPossitionRender Renderer { get; private set; }
        public Coordinate Possition { get; set; }
        public string Symbol { get; set; }
        public void Render()
        {
            Renderer.WritePossition(this.Possition, this.Symbol);
        }
    }
}
