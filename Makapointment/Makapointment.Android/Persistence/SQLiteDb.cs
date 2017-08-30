using Android.OS;
using Makapointment.Droid.Persistence;
using Makapointment.Persistence;
using SQLite;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using System.IO;
using Xamarin.Forms;
using SQLitePCL;
using SQLite.Net;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Makapointment.Droid.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
       
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "MySQLite.db3");
            var connectionString = new SQLiteConnectionString(path, false);
            var connectionWithLock = new SQLiteConnectionWithLock(new SQLitePlatformAndroid(), connectionString);

            return new SQLiteAsyncConnection(() => connectionWithLock);
        }
    }
    
}