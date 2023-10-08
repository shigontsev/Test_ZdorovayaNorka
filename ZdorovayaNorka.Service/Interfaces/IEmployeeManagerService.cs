using System.Collections.Generic;
using ZdorovayaNorka.Common.Entities;

namespace ZdorovayaNorka.Service.Interfaces
{
    public interface IEmployeeManagerService
    {
        Employee Create(Employee employee);

        Employee Update(Employee employee);

        bool Delete(int id);

        Employee Get(int id);

        IEnumerable<Employee> GetAllEmployees();

        IEnumerable<Employee> GetAllEmployees(int position_id);

        IEnumerable<Position> GetAllPositions();

    }
}
