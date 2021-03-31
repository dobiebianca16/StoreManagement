using System;
using SQLite;

namespace StoresManagementApp.Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
