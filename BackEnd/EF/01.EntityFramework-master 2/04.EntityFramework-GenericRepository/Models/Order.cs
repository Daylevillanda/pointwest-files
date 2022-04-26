using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EntityFrameworkDemo.Models
{
    [Index(nameof(CustomerId), Name = "IX_Orders_CustomerId")]
    public partial class Order : BaseEntity
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }

        [InverseProperty(nameof(ProductOrder.Order))]
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
