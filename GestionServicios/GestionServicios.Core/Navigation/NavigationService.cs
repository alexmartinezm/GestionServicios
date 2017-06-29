using Xamarin.Forms;

namespace GestionServicios.Core.Navigation
{
    /// <summary>
    /// Servicio que se encarga de navegar entre las pantallas de la app.
    /// </summary>
    public class NavigationService
    {
        /// <summary>
        /// Pantalla actual
        /// </summary>
        public static NavigationPage Current { get; set; }
    }
}