using System;
using System.Collections.Generic;

#nullable disable

namespace ToyUniverse.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string COrderNo { get; set; }
        public DateTime DOrderDate { get; set; }
        public string CCartId { get; set; }
        public string CShopperId { get; set; }
        public string CShippingModeId { get; set; }
        public decimal? MShippingCharges { get; set; }
        public decimal? MGiftWrapCharges { get; set; }
        public string COrderProcessed { get; set; }
        public decimal? MTotalCost { get; set; }
        public DateTime? DExpDelDate { get; set; }

        public virtual ShippingMode CShippingMode { get; set; }
        public virtual Shopper CShopper { get; set; }
        public virtual Recipient Recipient { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
