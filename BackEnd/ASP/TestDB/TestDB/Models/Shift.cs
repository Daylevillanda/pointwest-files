using System;
using System.Collections.Generic;

#nullable disable

namespace TestDB.Models
{
    public partial class Shift
    {
        public Shift()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int ShiftId { get; set; }
        public int PlacementContractId { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public byte NumberOfEmployees { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }

        public virtual PlacementContract PlacementContract { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
