using System;
using System.Collections.Generic;

namespace EntityFrameworkDemo.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime? OrderFulfilled { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        // Intersection table. Many-to-Many relationship
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}