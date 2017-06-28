using System.Collections.Generic;
using System.Linq;

namespace GestionServicios.Domain.Models.Base.Handle_Id
{
    /// <summary>
    /// Genera IDs cuando se crea una nueva entidad que herede de EntityBase
    /// y almacena en una lista de enteros todos los IDs.
    /// </summary>
    public static class GenerateIncrement
    {
        private static readonly IList<int> EntitiesList = new List<int>();

        private static void Add(int id)
        {
            EntitiesList.Add(id);
        }

        public static int Generate()
        {
            // Si no se ha creado ninguna entidad el Max no funciona, valor 0 si la lista está vacía
            var id = EntitiesList.Count != 0 ? EntitiesList.Max(i => i) + 1 : 0;
            Add(id);
            return id;
        }
    }
}