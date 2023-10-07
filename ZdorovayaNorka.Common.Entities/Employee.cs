using System;
using System.Collections.Generic;

#nullable disable

namespace ZdorovayaNorka.Common.Entities
{
    public partial class Employee
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public long PositionId { get; set; }

        public virtual Position Position { get; set; }
    }
}
