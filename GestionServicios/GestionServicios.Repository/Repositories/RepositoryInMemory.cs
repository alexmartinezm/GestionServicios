using System;
using System.Collections.Generic;
using System.Linq;
using GestionServicios.Domain.Models.Base;
using GestionServicios.Repository.Repositories.Interfaces;

namespace GestionServicios.Repository.Repositories
{
    public class RepositoryInMemory<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseModel, new()
    {
        private readonly MemoryContext _memoryContext;

        public RepositoryInMemory(MemoryContext memoryContext)
        {
            _memoryContext = memoryContext;
        }

        public TEntity Create(TEntity entity)
        {
            _memoryContext.GetList<TEntity>().Add(entity);
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public int Delete(Func<TEntity, bool> predicate)
        {

            var items = _memoryContext.GetList<TEntity>().Where(predicate).ToList();
            foreach (var item in items)
            {
                _memoryContext.GetList<TEntity>().Remove(item);
            }

            return items.Count();
        }

        public List<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _memoryContext.GetList<TEntity>().Where(predicate).ToList();
        }

        /// <summary>
        /// Actualiza una entidad.
        /// </summary>
        /// <param name="entityToUpdate">Entidad a actualizar</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>True si se ha actualizado.</returns>
        public bool Update(TEntity entityToUpdate)
        {
            var currentEntity = _memoryContext.GetList<TEntity>().First(e => e.Id == entityToUpdate.Id);
            var position = _memoryContext.GetList<TEntity>().IndexOf(currentEntity);
            _memoryContext.GetList<TEntity>().RemoveAt(position);
            _memoryContext.GetList<TEntity>().Insert(position, entityToUpdate);

            return _memoryContext.GetList<TEntity>().FirstOrDefault(e => e.Id == entityToUpdate.Id) != null;
        }
    }
}