using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace MvxMovies.Android
{
    [Activity(
    Label = "MvxMovies.Forms",
    MainLauncher = true,
    Icon = "@mipmap/icon",
    Theme = "@style/MainTheme",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
    LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            AiForms.Dialogs.Dialogs.Init(this); //need to write here
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }

}
