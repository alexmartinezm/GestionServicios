using System;
using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Repository.Factories
{
    public class GenericFactory<TEntity> where TEntity : new()
    {
        public static TEntity Create()
        {
            return new TEntity();
        }

        public static TEntity Create(params object[] parameters)
        {
            return (TEntity)Activator.CreateInstance(typeof(TEntity), parameters);
        }
    }
}
