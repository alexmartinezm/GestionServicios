using Xamarin.Forms;

namespace GestionServicios.Core.IOC
{
    public class Global
    {
        private static Global _instance;
        public ISqliteContext Context;

        protected Global()
        {
            Context = DependencyService.Get<ISqliteContext>();
        }

        public static Global GetInstance()
        {
            return _instance ?? (_instance = new Global());
        }
    }
}
