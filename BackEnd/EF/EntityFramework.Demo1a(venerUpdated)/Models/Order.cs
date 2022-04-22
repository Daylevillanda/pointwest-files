using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Demo1a.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime? OrderFulfilled { get; set; }

        // Foreign Key
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        // Intersection table - Many-to-Many Relationship
        public ICollection<ProductOrder> ProductOrders { get; set; }

    }
}
