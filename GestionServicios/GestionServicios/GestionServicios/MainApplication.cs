using GestionServicios.Core.Navigation;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Mocks.Mocks;
using GestionServicios.Repository.Factories;
using GestionServicios.Views;
using Xamarin.Forms;

namespace GestionServicios
{
    public class MainApplication : Application
    {
        public MainApplication()
        {
            // Contexto InMemory
            var context = new MemoryContext();

            FeedRepositoryInMemory(context);

            var navigationPage = new NavigationPage(new ShowServiciosView(context));

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

        #region Methods

        private void FeedRepositoryInMemory(MemoryContext context)
        {
            var repo = new RepositoryInMemoryFactory<Servicio>(context).Instance;
            foreach (var servicio in ServiciosMock.Servicios)
            {
                repo.Create(servicio);
            }
        }

        #endregion
    }
}
