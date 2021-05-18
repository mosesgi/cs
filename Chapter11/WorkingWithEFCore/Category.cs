using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        //defines a navigation property for related rows
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            //to enable developers to add products to a category we must initialize the navigation property to an empty collection
            this.Products = new HashSet<Product>();
        }
    }
}