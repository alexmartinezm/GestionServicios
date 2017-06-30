using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Repository.Factories
{
    public class GenericFactory<TEntity> where TEntity : new()
    {
        public static TEntity Create()
        {
            return new TEntity();
        }
    }
}
