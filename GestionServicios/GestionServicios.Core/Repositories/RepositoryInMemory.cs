using System;
using System.Collections.Generic;
using System.Linq;
using GestionServicios.Core.Repositories.Interfaces;
using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Core.Repositories
{
    public class RepositoryInMemory<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseModel, new()
    {
        private readonly IList<TEntity> _contextList;

        public RepositoryInMemory(IList<TEntity> contextList)
        {
            _contextList = contextList;
        }

        public TEntity Create(TEntity entity)
        {
            _contextList.Add(entity);
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public int Delete(Func<TEntity, bool> predicate)
        {

            var items = _contextList.Where(predicate).ToList();
            foreach (var item in items)
            {
                _contextList.Remove(item);
            }

            return items.Count();
        }

        public List<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _contextList.Where(predicate).ToList();
        }

        /// <summary>
        /// Actualiza una entidad.
        /// </summary>
        /// <param name="entityToUpdate">Entidad a actualizar</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>True si se ha actualizado.</returns>
        public bool Update(TEntity entityToUpdate)
        {
            var currentEntity = _contextList.First(e => e.Id == entityToUpdate.Id);
            var position = _contextList.IndexOf(currentEntity);
            _contextList.RemoveAt(position);
            _contextList.Insert(position, entityToUpdate);

            return _contextList.FirstOrDefault(e => e.Id == entityToUpdate.Id) != null;
        }
    }
}