using System;
using System.Xml.Serialization;

namespace Packt.Shared
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public class Shape
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

        public string Colour { get; set; }
        public virtual double Area 
        { 
            get
            {
                return width * height;
            }
        }

    }

    public class Rectangle : Shape
    {
       
    }

    public class Square : Shape
    {
        
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
        
    }

    public class Circle : Shape
    {
        public double Radius
        {
            get; set;
        }
        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }
    }
}
