﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ZdorovayaNorka.Common.Entities;
using ZdorovayaNorka.DAL.Interfaces;

namespace ZdorovayaNorka.DAL.Repositories
{
    public class ShiftManagerRepository : IShiftManagerRepository
    {
        private ApplicationDBContext _db;

        public bool StartShift(int id, DateTime start_dateTime)
        {
            var employee = GetEmployee(id);
            if (employee == null)
            {
                return false;
            }

            var shift_last = employee.Shifts.LastOrDefault();
            if (shift_last == null)
            {
                using (_db = new ApplicationDBContext())
                {
                    _db.Shifts.Add(new Shift()
                    {
                        StartShiftDate = start_dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        EmployeId = employee.Id,
                    });

                    _db.SaveChanges();
                }

                return true;
            }

            if (shift_last.EndtShiftDate == null)
            {
                return false;
            }
            if (shift_last.EndtShift_DateTime < start_dateTime)
            {
                using (_db = new ApplicationDBContext())
                {
                    _db.Shifts.Add(new Shift()
                    {
                        StartShiftDate = start_dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        EmployeId = employee.Id,
                    });

                    _db.SaveChanges();
                }

                return true;
            }

            return false;
        }

        public bool EndShift(int id, DateTime end_dateTime)
        {
            var employee = GetEmployee(id);
            if (employee == null)
            {
                return false;
            }

            var shift_last = employee.Shifts.LastOrDefault();
            if (shift_last == null)
            {
                return false;
            }
            if (shift_last.EndtShiftDate == null && shift_last.StartShift_DateTime < end_dateTime)
            {
                shift_last.EndtShiftDate = end_dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                shift_last.NumberOfHours = (int)((TimeSpan)(shift_last.EndtShift_DateTime - shift_last.StartShift_DateTime)).TotalHours;
                using (_db = new ApplicationDBContext())
                {
                    var shift_upd = new Shift()
                    {
                        Id = shift_last.Id,
                        StartShiftDate = shift_last.StartShiftDate,
                        EndtShiftDate = shift_last.EndtShiftDate,
                        NumberOfHours = shift_last.NumberOfHours,
                        EmployeId = employee.Id,
                    };
                    //_db.Shifts.Update(shift_last);
                    _db.Shifts.Update(shift_upd);

                    _db.SaveChanges();
                }                

                return true;
            }

            return false;
        }

        private Employee GetEmployee(int id)
        {
            using (_db = new ApplicationDBContext())
            {
                return _db.Employees.Include(x => x.Shifts).FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
