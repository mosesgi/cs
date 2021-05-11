using System.Text.RegularExpressions; 
namespace Packt.Shared 
{ 
    //These two changes tell the compiler that it should treat the method as one that extends the string type.
    //static, this
  public static class StringExtensions 
  { 
    public static bool IsValidEmail(this string input) 
    { 
      // use simple regular expression to check 
      // that the input string is a valid email 
      return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+"); 
    }
  }
}