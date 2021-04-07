using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height 
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("invalid height!");
                }
                this.height = value;
            }
        }

        public double Width 
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("invalid width!");
                }
                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }   

    }
}
