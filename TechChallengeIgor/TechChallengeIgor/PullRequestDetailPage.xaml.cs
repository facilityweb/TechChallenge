using Autofac;
using TechChallengeIgor.Infra;
using TechChallengeIgor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechChallengeIgor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PullRequestDetailPage : ContentPage
    {
        PullRequestDetailPageViewModel viewModel;
        public PullRequestDetailPage(string html_url)
        {
            InitializeComponent();
            viewModel = AppContainer.Container.Resolve<PullRequestDetailPageViewModel>();
            viewModel.DetailHtml = html_url;
            webViewDetail.Navigated += WebViewDetail_Navigated;
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadingOn();
        }
        private void WebViewDetail_Navigated(object sender, WebNavigatedEventArgs e)
        {
            viewModel.LoadingOff();
        }
    }
}