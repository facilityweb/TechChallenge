
using Android.App;
using Android.Content.PM;
using Android.OS;
using Autofac;
using TechChallengeIgor.Domain.Interfaces;
using TechChallengeIgor.Droid.DependencyServices;

namespace TechChallengeIgor.Droid
{
    [Activity(Label = "TechChallengeIgor", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }
        protected override void OnCreate(Bundle bundle)
        {
            Instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AppSetup(CreateContainer())));
        }

        public ContainerBuilder CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Connectivity_Android>().As<IConnectivityInfomation>().InstancePerDependency();
            return containerBuilder;
        }
    }
}

