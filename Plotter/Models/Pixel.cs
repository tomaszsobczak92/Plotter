using System;
using System.Drawing;

namespace Plotter.Models
{
    public class Pixel
    {
        public decimal X { get; private set; }
        public decimal Y { get; private set; }
        public Color Color { get; private set; }

        public Pixel (decimal x, decimal y, Color color)
        {
            SetX(x);
            SetY(y);
            Color = color;
        }

        private void SetX(decimal x)
        {
            if (x > 1 || x < 0)
                throw new ArgumentException("Pixel properties X have to be between 0 and 1");
            X = x;
        }

        private void SetY(decimal y)
        {
            if (y > 1 || y < 0)
                throw new ArgumentException("Pixel properties Y have to be between 0 and 1");
            Y = y;
        }
    }
}
