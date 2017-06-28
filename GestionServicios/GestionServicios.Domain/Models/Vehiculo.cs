using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Vehiculo : BaseModel
    {
        #region Fields

        private string _matricula;
        private Persona _propietario;

        #endregion

        #region Properties

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; RaiseOnPropertyChanged(); }
        }

        public Persona Propietario
        {
            get { return _propietario; }
            set { _propietario = value; RaiseOnPropertyChanged(); }
        }

        #endregion
    }
}