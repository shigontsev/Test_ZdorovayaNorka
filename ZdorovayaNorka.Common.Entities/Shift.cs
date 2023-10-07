using System;
using System.Collections.Generic;

#nullable disable

namespace ZdorovayaNorka.Common.Entities
{
    public partial class Shift
    {
        public int Id { get; set; }
        public DateTime StartShiftDate { get; set; }
        public DateTime EndtShiftDate { get; set; }
        public int? NumberOfHours { get; set; }
        public int EmployeId { get; set; }
    }
}
