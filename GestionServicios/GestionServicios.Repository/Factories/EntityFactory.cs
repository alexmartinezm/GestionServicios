using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Repository.Factories
{
    public class EntityFactory<TEntity> : IFactory<TEntity> where TEntity : BaseModel, new()
    {
        public TEntity Create()
        {
            return new TEntity();
        }
    }
}
