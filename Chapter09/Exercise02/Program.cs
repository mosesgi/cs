using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using Packt.Shared;

using static System.Console;

namespace Exercise02
{
    class Program
    {
        static string path = Path.Combine(Environment.CurrentDirectory, "shapes.xml");
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>
            {
                new Circle { Colour = "Red", Radius = 2.5 },
                new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
                new Circle { Colour = "Green", Radius = 8.0 },
                new Circle { Colour = "Purple", Radius = 12.3 },
                new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
            };
            SeriaXML(listOfShapes);
            DeseriaXML();
        }

        static void SeriaXML(List<Shape> shapes)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Shape>));
            
            using (FileStream stream = File.Create(path))
            {
                xs.Serialize(stream, shapes);
            }
        }

        static void DeseriaXML()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Shape>));
            using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            {
                var loadedShapes = (List<Shape>)xs.Deserialize(xmlLoad);
                foreach (Shape item in loadedShapes)
                {
                    WriteLine("{0} is {1} and has an area of {2:N2}",
                        item.GetType().Name, item.Colour, item.Area);
                }
            }
        }
    }
}
