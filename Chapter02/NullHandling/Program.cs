#nullable enable
using System;

namespace NullHandling
{
  class Address
  {
    public string? Building;
    public string Street = string.Empty;
    public string City = string.Empty;
    public string Region = string.Empty;
  }

  class Program
  {
    static void Main(string[] args)
    {
      int thisCannotBeNull = 4;
      string? test = null;
      //thisCannotBeNull = null; // compile error!

      int? thisCouldBeNull = null;
      Console.WriteLine(thisCouldBeNull);
      Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

      thisCouldBeNull = 7;
      Console.WriteLine(thisCouldBeNull);
      Console.WriteLine(thisCouldBeNull.GetValueOrDefault());
      if (thisCouldBeNull.HasValue)
      {
        Console.WriteLine(thisCouldBeNull==7);
        Console.WriteLine(thisCouldBeNull.Value==7);
      }

      var address = new Address();
      address.Building = null;
      address.Street = null;
      address.City = "London";
      address.Region = null;
    }
  }
}