using System;
using System.Collections.Generic;

#nullable disable

namespace TestDB.Models
{
    public partial class Location
    {
        public Location()
        {
            PlacementContracts = new HashSet<PlacementContract>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PlacementContract> PlacementContracts { get; set; }
    }
}
