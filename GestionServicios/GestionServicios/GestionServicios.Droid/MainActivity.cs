using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace GestionServicios.Droid
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            var a = Resources.GetDrawable(Resource.Drawable.ic_borrador_valido);

            //DependencyService.Register<SqliteDroid>();
            //DependencyService.Register<SqliteDataContext>();

            LoadApplication(new MainApplication());
        }
    }
}

