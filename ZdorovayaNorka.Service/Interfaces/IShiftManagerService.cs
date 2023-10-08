using System;

namespace ZdorovayaNorka.Service.Interfaces
{
    public interface IShiftManagerService
    {
        bool StartShift(int id, DateTime start_dateTime);

        bool EndShift(int id, DateTime end_dateTime);
    }
}
