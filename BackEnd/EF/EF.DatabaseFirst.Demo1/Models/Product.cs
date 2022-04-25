using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DatabaseFirst.Demo1.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductOders = new HashSet<ProductOder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }

        public virtual ICollection<ProductOder> ProductOders { get; set; }
    }
}
