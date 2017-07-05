using Xamarin.Forms;

namespace GestionServicios.Views.Base
{
    internal abstract class BaseView : ContentPage
    {
        protected BaseView()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            InitControls();
            // ReSharper disable once VirtualMemberCallInConstructor
            BuildView();
        }

        public abstract void InitControls();

        public abstract void BuildView();
    }
}