using System;
using System.Collections.Generic;

#nullable disable

namespace ToyUniverse.Data.Models
{
    public partial class Wrapper
    {
        public Wrapper()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string CWrapperId { get; set; }
        public string VDescription { get; set; }
        public decimal MWrapperRate { get; set; }
        public byte[] ImPhoto { get; set; }
        public string VWrapperImgPath { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
