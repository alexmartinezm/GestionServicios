using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GestionServicios.Core.Repositories.Interfaces;
using GestionServicios.Domain.Models;
using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Core.Repositories
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

    public interface IMemoryContext
    {
        IList<TEntity> GetList<TEntity>() where TEntity : BaseModel, new();
    }

    public class MemoryContext : IMemoryContext
    {
        public IList<Agente> Agentes { get; set; } = new List<Agente>();
        public IList<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
        public IList<Servicio> Servicios { get; set; } = new List<Servicio>();
        public IList<Calle> Calles { get; set; } = new List<Calle>();
        public IList<Persona> Personas { get; set; } = new List<Persona>();
        public IList<Lugar> Lugares { get; set; } = new List<Lugar>();

        public IList<TEntity> GetList<TEntity>() where TEntity : BaseModel, new()
        {
            var props = GetType().GetRuntimeProperties();
            var propertyInfo = props.FirstOrDefault(info => info.PropertyType == typeof(IList<TEntity>));
            return propertyInfo.GetValue(this) as IList<TEntity>;
        }
    }
}