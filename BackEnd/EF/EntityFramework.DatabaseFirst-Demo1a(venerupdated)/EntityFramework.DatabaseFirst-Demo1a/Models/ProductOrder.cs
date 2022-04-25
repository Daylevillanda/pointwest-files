using System;
using System.Collections.Generic;

namespace EntityFramework.DatabaseFirst_Demo1a.Models
{
    public partial class ProductOrder: BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
