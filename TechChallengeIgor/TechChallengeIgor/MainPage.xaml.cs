using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeIgor.Infra;
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
            viewModel = AppContainer.Container.Resolve<MainPageViewModel>();
            viewModel.TryAgainCommand = new Command(() => viewModel.GetItens());
            this.BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
