using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Agente : BaseModel
    {
        #region Fields

        private int? _tip;

        #endregion

        #region Properties

        public int? Tip
        {
            get { return _tip; }
            set { _tip = value; RaiseOnPropertyChanged(); }
        }

        #endregion
    }
}