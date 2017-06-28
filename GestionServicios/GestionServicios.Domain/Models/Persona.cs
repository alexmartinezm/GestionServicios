using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Persona : BaseModel
    {
        #region Fields

        private string _dni;

        #endregion

        #region Properties

        public string Dni
        {
            get { return _dni; }
            set { _dni = value; RaiseOnPropertyChanged(); }
        }

        #endregion
    }
}