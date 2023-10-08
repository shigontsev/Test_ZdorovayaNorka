using System;
using System.Collections.Generic;
using System.Linq;

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

        public virtual Position Position { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }

        /// <summary>
        /// Статистика нарушений
        /// </summary>
        public virtual ICollection<Statistics> ViolationStatistics
        {
            get
            {
                var a = Shifts.Where(y=>y.EndtShiftDate is not null).
                    GroupBy(x => new { Month = x.StartShift_DateTime.Month, Year = x.StartShift_DateTime.Year });

                var stat = new List<Statistics>();
                foreach (var g in a)
                {
                    int count = 0;
                    foreach (var b in g)
                    {
                        if (PositionId == 3)
                        {
                            //Вот тут я не понял по заданию, Тестировщики так же должны начинать минимум с 9ти?)
                            if (b.StartShift_DateTime.Hour == 9 && b.StartShift_DateTime.Minute > 0 ||
                                b.StartShift_DateTime.Hour > 9 ||
                                b.EndtShift_DateTime.Hour < 21)
                            { 
                                count++; 
                            }
                            continue;
                        }
                        else if (b.StartShift_DateTime.Hour == 9 && b.StartShift_DateTime.Minute > 0 ||
                                b.StartShift_DateTime.Hour > 9 ||
                            b.EndtShift_DateTime.Hour < 18)
                        { 
                            count++; 
                        }
                    }
                    
                    stat.Add(new Statistics
                    {
                        Date = new DateTime(g.Key.Year,g.Key.Month,1),
                        Count = count
                    });
                }

                return stat;
            }
        }
    }
}
