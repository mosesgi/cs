using System.Collections.Generic;
using Packt.Shared;

namespace NorthwindMvc.Models
{
    public class CreateCustomerViewModel
    {
        public Customer Customer { get; set; }
        public bool HasErrors { get; set; }
        public IEnumerable<string> ValidationErrors { get; set; }
    }
}