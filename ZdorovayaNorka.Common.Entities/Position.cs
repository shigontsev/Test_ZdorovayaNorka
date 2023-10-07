﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ZdorovayaNorka.Common.Entities
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        //public ICollection<Employee> Employees { get; set; }
    }
}
