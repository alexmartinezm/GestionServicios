using Android.App;
using Android.Content.PM;
using Android.OS;
using GestionServicios.Domain.DataContext;
using GestionServicios.Droid.Sqlite;
using Xamarin.Forms;

namespace GestionServicios.Droid
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            DependencyService.Register<SqliteDroid>();
            DependencyService.Register<SqliteDataContext>();

            LoadApplication(new MainApplication());
        }
    }
}

