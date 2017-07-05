using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Lugar : BaseModel
    {
        #region Fields

        private Calle _calle;
        private int _numero;

        #endregion

        #region Properties

        public Calle Calle
        {
            get { return _calle; }
            set { _calle = value; RaiseOnPropertyChanged();}
        }

        public int Numero
        {
            get { return _numero; }
            set { _numero = value; RaiseOnPropertyChanged();}
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Calle.Valor + ", " + Numero;
        }

        #endregion
    }
}