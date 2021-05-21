using System;

namespace Packt.Shared
{
    public abstract class Shape
    {
        protected double height;
        public virtual double Height 
        { 
            get
            {
                return height;
            }
            set
            {
                height = value;
            } 
        }
        protected double width;
        public virtual double Width
        {
            get
            {
                return width;
            } 
            set
            {
                width = value;
            } 
        }
        public abstract double Area { get; }

    }

    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            base.height = height;
            base.width = width;
        }
        public override double Area
        {
            get
            {
                return height * width;
            }
        }
    }

    public class Square : Shape
    {
        public Square(double width)
        {
            base.height = width;
            base.width = width;
        }
        public override double Width
        {
            set
            {
                width = value;
                height = value;
            }
        }
        public override double Height
        {
            set
            {
                width = value;
                height = value;
            }
        }
        public override double Area
        {
            get
            {
                return width * width;
            }
        }
    }

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            base.width = radius * 2;
            base.height = radius * 2;
        }

        public double Radius
        {
            get 
            {
                return width / 2;
            }
            set
            {
                width = value * 2;
                height = value * 2;
            }
        }
        public override double Area
        {
            get
            {
                return Math.PI * width * width / 4;
            }
        }
    }
}
