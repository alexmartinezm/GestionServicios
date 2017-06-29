using GestionServicios.Domain.MemoryContext;
using GestionServicios.ViewModels;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class ShowServiciosView : ContentPage
    {
        #region Fields

        private ListView _serviciosListView;
        private ToolbarItem _createServicioToolbarItem;

        #endregion

        #region Constructor

        public ShowServiciosView(MemoryContext context)
        {
            InitControls();
            BuildControls();
            BindingContext = new ShowServiciosViewModel(context);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inicializa los controles de la vista.
        /// </summary>
        private void InitControls()
        {
            _serviciosListView = new ListView()
            {

            };
        }

        /// <summary>
        /// Construye y muestra la vista.
        /// </summary>
        private void BuildControls()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
