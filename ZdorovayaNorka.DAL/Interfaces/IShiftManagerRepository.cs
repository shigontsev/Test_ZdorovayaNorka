using System;

namespace ZdorovayaNorka.DAL.Interfaces
{
    public interface IShiftManagerRepository
    {
        bool StartShift(int id, DateTime start_dateTime);

        bool EndShift(int id, DateTime end_dateTime);
    }
}
