using Android.OS;
using Makapointment.Droid.Persistence;
using Makapointment.Persistence;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Makapointment.Droid.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
       
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
    
}