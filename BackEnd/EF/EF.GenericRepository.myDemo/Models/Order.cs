using System;
using System.Collections.Generic;

#nullable disable

namespace EF.GenericRepository.myDemo.Models
{
    public partial class Order : BaseEntity
    {
        public Order()
        {
            ProductOders = new HashSet<ProductOder>();
        }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductOder> ProductOders { get; set; }
    }
}
