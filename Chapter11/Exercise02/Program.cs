using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Moses.Exercise;
using static System.Console;
using System.IO;
using System.Xml;
using System.Text.Json;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Northwind())
            {
                IQueryable<Category> categories = db.Categories.Include(p => p.Products);
                GenerateXmlFile(categories);
                GenerateJsonFile(categories);
            }
        }

        private static void GenerateXmlFile(IQueryable<Category> categories)
        {
            string xmlFile = "output.xml";
            using (FileStream stream = File.Create(Path.Combine(Environment.CurrentDirectory, xmlFile)))
            {
                using (XmlWriter xml = XmlWriter.Create(stream, new XmlWriterSettings{ Indent = true }))
                {
                    try
                    {
                        xml.WriteStartDocument();
                        xml.WriteStartElement("categories");
                        foreach (Category cat in categories)
                        {
                            xml.WriteStartElement("category");
                            xml.WriteElementString("id", cat.CategoryID.ToString());
                            xml.WriteElementString("name", cat.CategoryName);
                            xml.WriteElementString("desc", cat.Description);
                            xml.WriteElementString("product_count", cat.Products.Count.ToString());
                            xml.WriteStartElement("products");
                            foreach (Product p in cat.Products)
                            {
                                xml.WriteStartElement("product");
                                xml.WriteElementString("id", p.ProductID.ToString());
                                xml.WriteElementString("name", p.ProductName);
                                xml.WriteElementString("cost", p.Cost.Value.ToString());
                                xml.WriteEndElement();
                            }
                            xml.WriteEndElement();
                            xml.WriteEndElement();
                        }
                        xml.WriteEndElement();
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"{ex.GetType()} says {ex.Message}");
                    }
                }
            }
            WriteLine("{0} contains {1:N0} bytes.", xmlFile, new FileInfo(xmlFile).Length);
        }

        private static void GenerateJsonFile(IQueryable<Category> categories)
        {
            string jsonFile = "output.json";
            
            using (FileStream jsonStream = File.Create(Path.Combine(Environment.CurrentDirectory, jsonFile)))
            {
                using (var json = new Utf8JsonWriter(jsonStream, new JsonWriterOptions { Indented = true }) )
                {
                    json.WriteStartObject();
                    json.WriteStartArray("categories");
                    foreach (Category c in categories)
                    {
                        json.WriteStartObject();
                        json.WriteNumber("id", c.CategoryID);
                        json.WriteString("name", c.CategoryName);
                        json.WriteString("desc", c.Description);
                        json.WriteNumber("product_count", c.Products.Count);

                        json.WriteStartArray("products");
                        foreach (Product p in c.Products)
                        {
                            json.WriteStartObject();
                            json.WriteNumber("id", p.ProductID);
                            json.WriteString("name", p.ProductName);
                            json.WriteNumber("cost", p.Cost.Value);
                            json.WriteEndObject();
                        }
                        json.WriteEndArray();
                        json.WriteEndObject();
                    }
                    json.WriteEndArray();
                    json.WriteEndObject();
                }
            }
            WriteLine("{0} contains {1:N0} bytes.", jsonFile, new FileInfo(jsonFile).Length);
        }
    }
}
