using GestionServicios.Core.Navigation;
using GestionServicios.Domain.MemoryContext;
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

            var navigationPage = new NavigationPage(new ShowServiciosView(context));

            NavigationService.Current = navigationPage;

            // The root page of your application
            MainPage = navigationPage;

            //var test = new TabbedPage()
            //{
            //    Title = "Servicios",
            //    Children =
            //    {
            //        new Page()
            //        {
            //            Title = "weifhwiefuhweuf"
            //        },
            //        new Page()
            //        {
            //            Title = "sERVCRIWFWEJF"
            //        },
            //        new Page()
            //        {
            //            Title = "weifhwiefuhweuf"
            //        },
            //        new Page()
            //        {
            //            Title = "sERVCRIWFWEJF"
            //        },
            //        new Page()
            //        {
            //            Title = "weifhwiefuhweuf"
            //        },
            //        new Page()
            //        {
            //            Title = "sERVCRIWFWEJF"
            //        }
            //    }
            //};
            //;
            //MainPage = new NavigationPage(test);
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
