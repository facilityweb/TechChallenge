using TechChallengeIgor.Infra;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TechChallengeIgor
{
    public partial class App : Application
    {
        public App(AppSetup setup)
        {
            InitializeComponent();
            AppContainer.Container = setup.CreateContainer();
            MainPage = new MainPage();
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
