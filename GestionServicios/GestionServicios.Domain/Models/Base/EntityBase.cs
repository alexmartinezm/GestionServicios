using GestionServicios.Domain.Models.Base.Handle_Id;

namespace GestionServicios.Domain.Models.Base
{
    public abstract class EntityBase : GenerateIdInMemory
    {
        // Objeto locker para proteger las instrucciones
        private static readonly object Lock = new object();

        /// <summary>
        /// ID de la entidad
        /// </summary>
        public int Id { get; }

        protected EntityBase()
        {
            // Excluímos el objeto actual y lo liberamos al generar la ID
            lock (Lock)
            {
                Id = Generate();
            }
        }
    }
}