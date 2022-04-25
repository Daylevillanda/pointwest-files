using System;
using System.Collections.Generic;

#nullable disable

namespace EF.GenericRepository.myDemo.Models
{
    public partial class ProductOder : BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
