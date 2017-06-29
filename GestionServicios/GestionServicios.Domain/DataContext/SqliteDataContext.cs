using GestionServicios.Core.IOC;
using Xamarin.Forms;

namespace GestionServicios.Domain.DataContext
{
    public class SqliteDataContext : ISqliteContext
    {
        public ISqlite Database => DependencyService.Get<ISqlite>();
    }
}