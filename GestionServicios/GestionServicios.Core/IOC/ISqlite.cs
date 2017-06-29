using SQLite.Net;

namespace GestionServicios.Core.IOC 
{
    public interface ISqlite
    {
        string DataBasePath { get; set; }
        SQLiteConnection GetConnection();
    }
}