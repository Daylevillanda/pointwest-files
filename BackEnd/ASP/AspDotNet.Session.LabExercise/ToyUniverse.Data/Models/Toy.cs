using System;
using System.Collections.Generic;

#nullable disable

namespace ToyUniverse.Data.Models
{
    public partial class Toy
    {
        public Toy()
        {
            OrderDetails = new HashSet<OrderDetail>();
            PickOfMonths = new HashSet<PickOfMonth>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public string CToyId { get; set; }
        public string VToyName { get; set; }
        public string VToyDescription { get; set; }
        public string CCategoryId { get; set; }
        public decimal MToyRate { get; set; }
        public string CBrandId { get; set; }
        public byte[] ImPhoto { get; set; }
        public short SiToyQoh { get; set; }
        public short SiLowerAge { get; set; }
        public short SiUpperAge { get; set; }
        public short? SiToyWeight { get; set; }
        public string VToyImgPath { get; set; }

        public virtual ToyBrand CBrand { get; set; }
        public virtual Category CCategory { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<PickOfMonth> PickOfMonths { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
