using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace Moses.Exercise
{
    public class Category
    {
        public int CategoryID {get; set;}
        [Required]
        [StringLength(15)]
        public string CategoryName {get; set;}
        [Column(TypeName="ntext")]
        public string Description {get; set;}

        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    }
}