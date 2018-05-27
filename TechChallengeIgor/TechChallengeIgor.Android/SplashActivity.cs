
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;

namespace TechChallengeIgor.Droid
{
    [Activity(Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.StartActivity(typeof(MainActivity));
        }
    }
}