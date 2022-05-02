using System;
using System.Collections.Generic;

#nullable disable

namespace ToyUniverse.Data.Models
{
    public partial class Recipient
    {
        public string COrderNo { get; set; }
        public string VFirstName { get; set; }
        public string VLastName { get; set; }
        public string VAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CCountryId { get; set; }
        public string CZipCode { get; set; }
        public string CPhone { get; set; }

        public virtual Country CCountry { get; set; }
        public virtual Order COrderNoNavigation { get; set; }
    }
}
