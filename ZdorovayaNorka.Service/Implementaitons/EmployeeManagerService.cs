﻿using System.Collections.Generic;
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

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeManagerRepository.GetAllEmployees();
        }

        public IEnumerable<Employee> GetAllEmployees(int position_id)
        {
            return _employeeManagerRepository.GetAllEmployees(position_id);
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return _employeeManagerRepository.GetAllPositions();
        }

        public Employee Update(Employee employee)
        {
            return _employeeManagerRepository.Update(employee);
        }
    }
}
