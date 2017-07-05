using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestionServicios.ViewModels.Base
{
    internal class BaseViewModel : HandleView, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}