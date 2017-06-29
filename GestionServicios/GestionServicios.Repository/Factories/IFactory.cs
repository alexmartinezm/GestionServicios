using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Repository.Factories
{
    public interface IFactory<out TEntity> where TEntity : BaseModel, new()
    {
        TEntity Create();
    }
}