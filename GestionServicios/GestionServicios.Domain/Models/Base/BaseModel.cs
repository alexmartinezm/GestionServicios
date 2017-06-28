using System.ComponentModel;
using System.Runtime.CompilerServices;
using GestionServicios.Domain.Models.Base.Handle_Id;

namespace GestionServicios.Domain.Models.Base
{
    public abstract class BaseModel : GenerateIdInMemory, INotifyPropertyChanged
    {
        // Objeto locker para proteger las instrucciones
        private static readonly object Lock = new object();

        /// <summary>
        /// ID de la entidad
        /// </summary>
        public int Id { get; }

        protected BaseModel()
        {
            // Excluímos el objeto actual y lo liberamos al generar la ID
            lock (Lock)
            {
                Id = Generate();
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}