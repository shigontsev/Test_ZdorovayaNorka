using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdorovayaNorka.Common.Entities;
using ZdorovayaNorka.DAL.Interfaces;
using ZdorovayaNorka.Service.Interfaces;

namespace ZdorovayaNorka.Service.Implementaitons
{
    public class EmployeeManagerService : IEmployeeManagerService
    {
        readonly IEmployeeManagerRepository _employeeManagerRepository;

        public EmployeeManagerService(IEmployeeManagerRepository employeeManagerRepository)
        {
            _employeeManagerRepository = employeeManagerRepository;
        }

        public Employee Create(Employee employee)
        {
            return _employeeManagerRepository.Create(employee);
        }

        public bool Delete(int id)
        {
            return _employeeManagerRepository.Delete(id);
        }

        public Employee Get(int id)
        {
            return _employeeManagerRepository.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeManagerRepository.GetAll();
        }

        public IEnumerable<Employee> GetAll(int position_id)
        {
            return _employeeManagerRepository.GetAll(position_id);
        }

        public Employee Update(Employee employee)
        {
            return _employeeManagerRepository.Update(employee);
        }
    }
}
