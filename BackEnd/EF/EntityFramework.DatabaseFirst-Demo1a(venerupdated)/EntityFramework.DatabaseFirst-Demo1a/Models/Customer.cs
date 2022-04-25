using System;
using System.Collections.Generic;

namespace EntityFramework.DatabaseFirst_Demo1a.Models
{
    public partial class Customer: BaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
