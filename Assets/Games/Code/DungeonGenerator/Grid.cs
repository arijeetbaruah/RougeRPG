using System.Collections.Generic;
using UnityEngine;

namespace RougeRPG.Map
{
    public class Grid<T>
    {
        protected List<Cell<T>> cells;
        protected int width;
        protected int height;

        public int Width => width;
        public int Height => height;
        
        public Grid(int width, int height)
        {
            cells = new List<Cell<T>>(width * height);
            this.width = width;
            this.height = height;
        }

        public T Get(int x, int y)
        {
            return cells[x + y * width].Value;
        }

        public void Set(int x, int y, T value)
        {
            cells[x + y * width].Value = value;
        }
    }
}
