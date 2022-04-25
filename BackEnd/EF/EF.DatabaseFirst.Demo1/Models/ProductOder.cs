using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DatabaseFirst.Demo1.Models
{
    public partial class ProductOder
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
