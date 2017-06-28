using System;
using System.Collections.Generic;
using System.Linq;
using GestionServiciosUnitTest.Models.Base;

namespace GestionServiciosUnitTest.Repository
{
    internal class RepositoryInMemory<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase, new()
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
        /// 
        /// </summary>
        /// <param name="newEntity"></param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns></returns>
        public bool Update(TEntity newEntity)
        {
            var hasChanged = false;

            var currentEntity = _contextList.First(e => e.Id == newEntity.Id);
            var position = _contextList.IndexOf(currentEntity);
            _contextList.RemoveAt(position);
            _contextList.Insert(position, newEntity);

            //if (_contextList.FirstOrDefault(currentEntity) != null)
            //{
                
            //}

            return hasChanged;
        }
    }
}