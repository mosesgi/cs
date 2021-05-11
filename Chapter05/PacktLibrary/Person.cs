using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public partial class Person : object
    {
        public const string Species = "Homo Sapien";
        public readonly string HomePlanet = "Earth";
        public string Name;
        public DateTime DateOfBirth;
        public DateTime Instantiated;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        public Person () {}

        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }

        public (string Name, int Number) GetNamedFruit()
        {
            return ("Apple", 5);
        }

        public string OptionalParameters(
            string command = "Run!", 
            double number = 0.0, 
            bool active = true)
        {
            return string.Format(
                format: "command is {0}, number is {1}, active is {2}",
                arg0: command, arg1: number, arg2: active);
        }

    }
}
