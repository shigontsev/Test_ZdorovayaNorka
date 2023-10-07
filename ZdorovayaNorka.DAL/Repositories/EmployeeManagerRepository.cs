using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdorovayaNorka.Common.Entities;
using ZdorovayaNorka.DAL.Interfaces;

namespace ZdorovayaNorka.DAL.Repositories
{
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private ApplicationDBContext _db;

        public Employee Create(Employee employee)
        {
            if (employee == null) 
                return null;
            if(string.IsNullOrWhiteSpace(employee.FirstName) ||
                string.IsNullOrWhiteSpace(employee.LastName) ||
                employee.PositionId == 0)
                return null;

            using (_db = new ApplicationDBContext())
            {
                var check = _db.Employees.FirstOrDefault(e => e.FirstName == employee.FirstName && 
                e.LastName == employee.LastName && 
                e.MiddleName == employee.MiddleName);
                if (check != null)
                    return null;

                _db.Employees.Add(new Employee()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    PositionId = employee.PositionId,
                });
                _db.SaveChanges();

                //return employee;

                return _db.Employees.FirstOrDefault(e => e.FirstName == employee.FirstName &&
                e.LastName == employee.LastName &&
                e.MiddleName == employee.MiddleName);

                //return _db.Employees.LastOrDefault();
            }
        }

        public bool Delete(int id)
        {
            var employee = Get(id);
            if (employee == null)
            {
                return false;
            }
            using (_db = new ApplicationDBContext())
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }

            return true;
        }

        public Employee Get(int id)
        {
            using (_db = new ApplicationDBContext())
            {
                return _db.Employees.FirstOrDefault(x=>x.Id == id);
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using (_db = new ApplicationDBContext())
            {
                return _db.Employees.Include(x=>x.Position).ToArray();
            }
        }

        public IEnumerable<Employee> GetAll(int position_id)
        {
            using (_db = new ApplicationDBContext())
            {
                return _db.Employees.Where(x=>x.PositionId == position_id).Include(x => x.Position).ToArray();
            }
        }

        public Employee Update(Employee employee)
        {
            var check = Get(employee.Id);
            if (employee == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(employee.FirstName) ||
                string.IsNullOrWhiteSpace(employee.LastName) ||
                employee.PositionId == 0)
                return null;

            using (_db = new ApplicationDBContext()) {
                _db.Employees.Update(employee);
                _db.SaveChanges();
            }

            return employee;
        }
    }
}
