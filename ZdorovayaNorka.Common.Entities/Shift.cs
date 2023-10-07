using System;
using System.Collections.Generic;

#nullable disable

namespace ZdorovayaNorka.Common.Entities
{
    public partial class Shift
    {
        public long Id { get; set; }
        public DateTime StartShiftDate { get; set; }
        public DateTime EndtShiftDate { get; set; }
        public long? NumberOfHours { get; set; }
        public long EmployeId { get; set; }
    }
}
