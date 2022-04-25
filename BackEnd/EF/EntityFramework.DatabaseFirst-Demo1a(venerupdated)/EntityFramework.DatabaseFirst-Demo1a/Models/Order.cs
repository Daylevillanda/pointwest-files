using System;
using System.Collections.Generic;

namespace EntityFramework.DatabaseFirst_Demo1a.Models
{
    public partial class Order: BaseEntity
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

       
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
