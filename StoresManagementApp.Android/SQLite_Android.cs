using System;
using System.IO;
using SQLite;
using StoresManagementApp.Droid;
using StoresManagementApp.Model;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLite_Android))]

namespace StoresManagementApp.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqlliteFileName = "MyDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            
            var path = Path.Combine(documentsPath, sqlliteFileName); var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}
