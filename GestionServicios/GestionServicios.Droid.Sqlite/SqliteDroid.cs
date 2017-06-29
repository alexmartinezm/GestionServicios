using System.IO;
using GestionServicios.Core.IOC;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

namespace GestionServicios.Droid.Sqlite
{
    public class SqliteDroid : ISqlite
    {
        public string DataBasePath { get; set; }
        public SQLiteConnection GetConnection()
        {
            const string sqliteFilename = "GestionServicios.db3";

            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            DataBasePath = path;
            var plat = new SQLitePlatformAndroid();
            var conn = new SQLiteConnectionWithLock(plat, new SQLiteConnectionString(path, true));
            return conn;
        }
    }
}
