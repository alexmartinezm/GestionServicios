using GestionServicios.Views;
using Xamarin.Forms;

namespace GestionServicios
{
    public class MainApplication : Application
    {
        public MainApplication()
        {

            var navigationPage = new NavigationPage(new ShowServiciosView());

            NavigationService.Current = navigationPage;

            // The root page of your application
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
