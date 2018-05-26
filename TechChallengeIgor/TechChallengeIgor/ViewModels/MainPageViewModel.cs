using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Exceptions;
using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<HubItem> itens;
        public ObservableCollection<HubItem> ItensList
        {
            get { return itens; }
            set
            {
                if (itens != value)
                {
                    itens = value;
                    OnPropertyChanged("ItensList");
                }
            }
        }
        public override ICommand TryAgainCommand { get; set; }
        private readonly IGitHubDomainService _gitHubDomainService;
        public MainPageViewModel(IGitHubDomainService gitHubDomainService)
        {
            this._gitHubDomainService = gitHubDomainService;
        }
        public async Task GetItensAsync()
        {
            try
            {
                LoadingOn();
                var model = await this._gitHubDomainService.GetGitHubMostPopularJavascriptRepositorys(SystemInfra.MaxNumberOfRepositorys);
                this.ItensList = new ObservableCollection<HubItem>(model.items);
                LoadingOff();
            }
            catch (NoConectivityException)
            {
                this.ErrorOcurred(SystemInfra.NoConectivityErrorMessage);
                LoadingOff();
            }
            catch (Exception)
            {
                this.ErrorOcurred();
                LoadingOff();
            }
        }
    }
}
