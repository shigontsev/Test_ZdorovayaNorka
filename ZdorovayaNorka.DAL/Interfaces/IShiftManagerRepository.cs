using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdorovayaNorka.DAL.Interfaces
{
    public interface IShiftManagerRepository
    {
        bool StartShift(int id, DateTime start_dateTime);

        bool EndShift(int id, DateTime end_dateTime);
    }
}
