using System;
using System.Collections.Generic;

namespace GestionServicios.Repository.Repositories.Interfaces
{
    public interface IRepositoryBase <TEntity> where TEntity : class, new()
    {
        TEntity Create(TEntity entity);

        List<TEntity> Find(Func<TEntity, bool> predicate);

        bool Update(TEntity entityToUpdate);

        int Delete(Func<TEntity, bool> predicate);
    }
}