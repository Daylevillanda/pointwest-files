using System;
using System.Collections.Generic;

namespace EntityFramework.DatabaseFirst_Demo1a.Models
{
    public partial class Product: BaseEntity
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
