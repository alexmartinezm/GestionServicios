using System.Collections.Generic;
using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.MemoryContext
{
    public interface IMemoryContext
    {
        IList<TEntity> GetList<TEntity>() where TEntity : BaseModel, new();
    }
}