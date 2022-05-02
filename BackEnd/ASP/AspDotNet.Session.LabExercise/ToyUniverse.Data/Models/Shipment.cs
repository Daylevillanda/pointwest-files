using System;
using System.Collections.Generic;

#nullable disable

namespace ToyUniverse.Data.Models
{
    public partial class Shipment
    {
        public string COrderNo { get; set; }
        public DateTime? DShipmentDate { get; set; }
        public string CDeliveryStatus { get; set; }
        public DateTime? DActualDeliveryDate { get; set; }

        public virtual Order COrderNoNavigation { get; set; }
    }
}
