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
            this.BindingContext = viewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.viewModel.GetItensAsync();
        }
    }
}
