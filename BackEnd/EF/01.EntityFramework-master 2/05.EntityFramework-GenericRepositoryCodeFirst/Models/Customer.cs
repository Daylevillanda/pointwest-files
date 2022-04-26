using System.Collections.Generic;

namespace EntityFrameworkDemo.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        // Navigation Property. One-to-Many
        public ICollection<Order> Orders { get; set; }

    }
}
