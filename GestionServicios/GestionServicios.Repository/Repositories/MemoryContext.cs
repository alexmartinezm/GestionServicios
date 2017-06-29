using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GestionServicios.Domain.Models;
using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Repository.Repositories
{
    /// <summary>
    /// Contexto en memoria que contiene una lista por cada entidad.
    /// </summary>
    public class MemoryContext : IMemoryContext
    {
        #region Properties

        public IList<Agente> Agentes { get; set; } = new List<Agente>();
        public IList<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
        public IList<Servicio> Servicios { get; set; } = new List<Servicio>();
        public IList<Calle> Calles { get; set; } = new List<Calle>();
        public IList<Persona> Personas { get; set; } = new List<Persona>();
        public IList<Lugar> Lugares { get; set; } = new List<Lugar>();

        #endregion

        public IList<TEntity> GetList<TEntity>() where TEntity : BaseModel, new()
        {
            var props = GetType().GetRuntimeProperties();
            var propertyInfo = props.FirstOrDefault(info => info.PropertyType == typeof(IList<TEntity>));
            return propertyInfo.GetValue(this) as IList<TEntity>;
        }
    }
}