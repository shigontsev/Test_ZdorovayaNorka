using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        /// <summary>
        /// Статистика нарушений
        /// </summary>
        public virtual ICollection<Statistics> ViolationStatistics
        {
            get
            {
                //var v = Shifts.GroupBy(x => x.Id);
                //var a = (from shift in Shifts
                //         where shift.EndtShiftDate is not null
                //         select new Shift
                //         {
                //             Id = shift.Id,
                //             StartShiftDate = shift.StartShiftDate,
                //             EndtShiftDate = shift.EndtShiftDate,
                //             NumberOfHours = shift.NumberOfHours,
                //             EmployeId = shift.EmployeId
                //         }).GroupBy(x => new { Month = x.StartShift_DateTime.Month, Year = x.StartShift_DateTime.Year });

                var a = Shifts.Where(y=>y.EndtShiftDate is not null).
                    GroupBy(x => new { Month = x.StartShift_DateTime.Month, Year = x.StartShift_DateTime.Year });

                //if (a.Count() > 0 )
                //{
                //    return new List<Statistics>();
                //}
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

                    //string dateString = $"{g.Key.Month}/{g.Key.Year}";
                    //CultureInfo provider = CultureInfo.InvariantCulture;
                    //DateTime dateresult;
                    //DateTime.TryParseExact(dateString, "MM/yyyy", provider, DateTimeStyles.None, out dateresult);
                    //stat.Add(new Statistics
                    //{
                    //    Date = dateresult,
                    //    Count = count
                    //}) ;
                    
                    stat.Add(new Statistics
                    {
                        Date = new DateTime(g.Key.Year,g.Key.Month,1),
                        Count = count
                    });
                    //var ori = new Statistics()
                    //{
                    //    Date = new DateTime() { }
                    //    Id = g.Key,
                    //    UserId = g.First().UserId,
                    //    UserName = g.First().UserName,
                    //    Count = g.Count(),
                    //    Sum = g.Sum(x => x.Price)
                    //};
                    //orders.Add(ori);
                }

                return stat;
            }
        }

        //public ICollection<ViolationStatistics> Stroka => new List<ViolationStatistics>();


        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}


    }
}
