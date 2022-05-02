using System;
using System.Collections.Generic;

#nullable disable

namespace ToyUniverse.Data.Models
{
    public partial class ShippingMode
    {
        public ShippingMode()
        {
            Orders = new HashSet<Order>();
            ShippingRates = new HashSet<ShippingRate>();
        }

        public string CModeId { get; set; }
        public string CMode { get; set; }
        public int? IMaxDelDays { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShippingRate> ShippingRates { get; set; }
    }
}
