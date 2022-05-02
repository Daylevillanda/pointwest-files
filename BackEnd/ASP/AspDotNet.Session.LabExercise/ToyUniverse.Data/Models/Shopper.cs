using System;
using System.Collections.Generic;

#nullable disable

namespace ToyUniverse.Data.Models
{
    public partial class Shopper
    {
        public Shopper()
        {
            Orders = new HashSet<Order>();
        }

        public string CShopperId { get; set; }
        public string CPassword { get; set; }
        public string VFirstName { get; set; }
        public string VLastName { get; set; }
        public string VEmailId { get; set; }
        public string VAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CCountryId { get; set; }
        public string CZipCode { get; set; }
        public string CPhone { get; set; }
        public string CCreditCardNo { get; set; }
        public string VCreditCardType { get; set; }
        public DateTime? DExpiryDate { get; set; }

        public virtual Country CCountry { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
