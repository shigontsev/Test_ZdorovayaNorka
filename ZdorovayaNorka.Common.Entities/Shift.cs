using System;

namespace ZdorovayaNorka.Common.Entities
{
    public partial class Shift
    {
        public int Id { get; set; }
        public string? StartShiftDate { get; set; }
        public string? EndtShiftDate { get; set; }

        //public virtual DateTime? StartShift_DateTime => string.IsNullOrWhiteSpace(StartShiftDate)? null: DateTime.Parse(StartShiftDate);

        //public virtual DateTime? EndtShift_DateTime => string.IsNullOrWhiteSpace(EndtShiftDate) ? null : DateTime.Parse(EndtShiftDate);

        public virtual DateTime StartShift_DateTime => DateTime.Parse(StartShiftDate);

        public virtual DateTime EndtShift_DateTime => 
            string.IsNullOrWhiteSpace(EndtShiftDate)? DateTime.MinValue : DateTime.Parse(EndtShiftDate);
        public int? NumberOfHours { get; set; }
        public int EmployeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
