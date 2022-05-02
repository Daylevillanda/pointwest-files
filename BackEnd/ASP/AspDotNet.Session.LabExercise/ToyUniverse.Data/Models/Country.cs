using System;
using System.Collections.Generic;

#nullable disable

namespace ToyUniverse.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            Recipients = new HashSet<Recipient>();
            ShippingRates = new HashSet<ShippingRate>();
            Shoppers = new HashSet<Shopper>();
        }

        public string CCountryId { get; set; }
        public string CCountry { get; set; }

        public virtual ICollection<Recipient> Recipients { get; set; }
        public virtual ICollection<ShippingRate> ShippingRates { get; set; }
        public virtual ICollection<Shopper> Shoppers { get; set; }
    }
}
