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

namespace TechChallengeIgor
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            this.Title = SystemInfra.MainPageTitle;
            viewModel = AppContainer.Container.Resolve<MainPageViewModel>();
            viewModel.TryAgainCommand = new Command(async () => await viewModel.GetItensAsync());
            lstView.ItemTemplate = new DataTemplate(() => new RepositoriesViewCell());
            lstView.ItemSelected += LstView_ItemSelected;
            srchBarItens.TextChanged += SrchBarItens_TextChanged;
            this.BindingContext = viewModel;
        }

        private void SrchBarItens_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstView.BeginRefresh();

            viewModel.SearchItens(e.NewTextValue);

            lstView.EndRefresh();
        }

        private void LstView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new PullRequestsPage(viewModel.SelectedItem));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.viewModel.GetItensAsync();
        }
    }
}
