using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleMaintanence.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
