using System;
using System.Collections.Generic;

#nullable disable

namespace EF.GenericRepository.myDemo.Models
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            ProductOders = new HashSet<ProductOder>();
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }

        public virtual ICollection<ProductOder> ProductOders { get; set; }
    }
}
