using System;
using System.IO;

using SQLite;
using StoresManagementApp.iOS;
using StoresManagementApp.Model;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLite_iOS))]

namespace StoresManagementApp.iOS
{
    public class SQLite_iOS :ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqlliteFileName = "MyDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqlliteFileName);var cn = new SQLiteConnection(path);
            return cn;
        }


    }
}
