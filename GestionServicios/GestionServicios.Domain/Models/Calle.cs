using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Calle : BaseModel
    {
        #region Fields

        private string _valor;

        #endregion

        #region Properties

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; RaiseOnPropertyChanged(); }
        }

        #endregion
    }
}