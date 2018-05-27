using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Exceptions;
using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.ViewModels
{
    public class PullRequestsPageViewModel : BaseViewModel
    {
        private ObservableCollection<PullRequestItem> itens;
        public ObservableCollection<PullRequestItem> ItensList
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
        private bool layoutIsVisible;

        public bool LayoutIsVisible
        {
            get { return layoutIsVisible; }
            set
            {
                if (layoutIsVisible != value)
                {
                    layoutIsVisible = value;
                    OnPropertyChanged("LayoutIsVisible");
                }
            }
        }

        public PullRequestItem SelectedItem { get; set; }
        public override ICommand TryAgainCommand { get; set; }
        public HubItem HubItem { get; set; }
        private readonly IGitHubDomainService _gitHubDomainService;
        public PullRequestsPageViewModel(IGitHubDomainService gitHubDomainService)
        {
            this._gitHubDomainService = gitHubDomainService;
        }
        public async Task GetPullRequests()
        {
            try
            {
                LoadingOn();
                LayoutIsVisible = false;
                var list = await _gitHubDomainService.GetPullRequestsFromRepository(HubItem.pulls_formated_url);
                this.ItensList = new ObservableCollection<PullRequestItem>(list);
                LoadingOff();
                LayoutIsVisible = true;
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
