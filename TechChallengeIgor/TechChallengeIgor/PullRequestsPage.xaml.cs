using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Infra;
using TechChallengeIgor.VIewCells;
using TechChallengeIgor.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechChallengeIgor
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PullRequestsPage : ContentPage
	{
        private PullRequestsPageViewModel viewModel;
        public PullRequestsPage (HubItem hubItem)
		{
			InitializeComponent ();
            this.Title = hubItem.full_name;
            viewModel = AppContainer.Container.Resolve<PullRequestsPageViewModel>();
            viewModel.HubItem = hubItem;
            viewModel.TryAgainCommand = new Command(async () => await viewModel.GetPullRequests());
            lstView.ItemTemplate = new DataTemplate(() => new PullRequestsViewCell());
            lstView.ItemSelected += LstView_ItemSelected;
            OpeningText.TextColor = Color.FromHex("#e19a17");
            this.BindingContext = viewModel;
        }

        private void LstView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PullRequestDetailPage(viewModel.HubItem.html_url));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.GetPullRequests();
        }
    }
}