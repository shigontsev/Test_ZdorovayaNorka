using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdorovayaNorka.DAL.Interfaces;
using ZdorovayaNorka.Service.Interfaces;

namespace ZdorovayaNorka.Service.Implementaitons
{
    public class ShiftManagerService : IShiftManagerService
    {
        readonly IShiftManagerRepository _shiftManagerRepository;

        public ShiftManagerService(IShiftManagerRepository shiftManagerRepository)
        {
            _shiftManagerRepository = shiftManagerRepository;
        }

        public bool EndShift(int id, DateTime end_dateTime)
        {
            return _shiftManagerRepository.EndShift(id, end_dateTime);
        }

        public bool StartShift(int id, DateTime start_dateTime)
        {
            return _shiftManagerRepository.StartShift(id, start_dateTime);
        }
    }
}
