using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidApplication;

namespace AzgebMonoGameStartingpoint {
    [Activity(Label = "AzgebMonoGameStartingpoint"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Landscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize | ConfigChanges.ScreenLayout)]
    public class Activity1:Microsoft.Xna.Framework.AndroidGameActivity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            var s = new SceneManager();
            SetContentView((View)s.Services.GetService(typeof(View)));
            s.Run();
        }
    }
}

