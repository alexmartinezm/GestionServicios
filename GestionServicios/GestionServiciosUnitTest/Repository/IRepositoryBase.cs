using System;
using System.Collections.Generic;

namespace GestionServiciosUnitTest.Repository
{
    internal interface IRepositoryBase <TEntity> where TEntity : class, new()
    {
        TEntity Create(TEntity entity);

        List<TEntity> Find(Func<TEntity, bool> predicate);

        int Update(TEntity newEntity);

        int Delete(Func<TEntity, bool> predicate);
    }
}