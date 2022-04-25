using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DatabaseFirst.Demo1.Models
{
    public partial class Order
    {
        public Order()
        {
            ProductOders = new HashSet<ProductOder>();
        }

        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductOder> ProductOders { get; set; }
    }
}
