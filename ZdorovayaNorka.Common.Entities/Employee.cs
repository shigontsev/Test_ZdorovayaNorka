using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

//#nullable disable

namespace ZdorovayaNorka.Common.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Shifts = new HashSet<Shift>();
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public int PositionId { get; set; }

        //[JsonIgnore]
        public virtual Position Position { get; set; }

        ////[JsonIgnore]
        //public Position? Position { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }

    }
}
