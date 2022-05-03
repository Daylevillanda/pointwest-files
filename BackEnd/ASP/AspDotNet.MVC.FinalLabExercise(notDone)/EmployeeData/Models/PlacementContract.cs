using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeData.Models
{
    public partial class PlacementContract
    {
        public PlacementContract()
        {
            Shifts = new HashSet<Shift>();
        }

        public int PlacementContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
