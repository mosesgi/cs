namespace Packt.Shared
{
    public class ImmutablePerson
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }

    /*
        After initialization the value cannot be changed
    */
    public record ImmutableVehicle
    {
        public int Wheels { get; init; }
        public string Color { get; init; }
        public string Brand {get; init; }
    }

    public record ImmutableAnimal
    {
        string Name;        // public init-only properties in record.
        string Species;
        public ImmutableAnimal(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public void Deconstruct(out string name, out string species)
        {
            name = Name;
            species = Species;
        }
    }
}