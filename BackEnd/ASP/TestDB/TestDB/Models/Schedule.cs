using System;
using System.Collections.Generic;

#nullable disable

namespace TestDB.Models
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime Day { get; set; }
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public decimal HourlyWage { get; set; }
        public bool OverTime { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
