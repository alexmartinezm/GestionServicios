namespace GestionServicios.Core.IOC
{
    public interface ISqliteContext
    {
        ISqlite Database { get; }
    }
}