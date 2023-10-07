using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdorovayaNorka.Common.Entities;

namespace ZdorovayaNorka.DAL.Interfaces
{
    public interface IEmployeeManagerRepository
    {
        Employee Create(Employee employee);

        Employee Update(Employee employee);

        bool Delete(int id);

        Employee Get(int id);

        //Employee Get(string name);

        IEnumerable<Employee> GetAll();

        IEnumerable<Employee> GetAll(int position_id);

    }
}
