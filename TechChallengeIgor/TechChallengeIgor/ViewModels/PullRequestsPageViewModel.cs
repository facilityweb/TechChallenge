using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private string openingText;

        public string OpeningText
        {
            get { return openingText; }
            set
            {
                if (openingText != value)
                {
                    openingText = value;
                    OnPropertyChanged("OpeningText");
                }
            }
        }

        private string closedText;

        public string ClosedText
        {
            get { return closedText; }
            set
            {
                if (closedText != value)
                {
                    closedText = value;
                    OnPropertyChanged("ClosedText");
                }
            }
        }
        public PullRequestItem SelectedItem { get; set; }
        public override ICommand TryAgainCommand { get; set; }
        public HubItem HubItem { get; set; }
        private IList<PullRequestItem> list;
        private readonly IGitHubDomainService _gitHubDomainService;
        public PullRequestsPageViewModel(IGitHubDomainService gitHubDomainService)
        {
            this._gitHubDomainService = gitHubDomainService;
            list = new List<PullRequestItem>();
        }
        public async Task GetPullRequests()
        {
            try
            {
                LoadingOn();
                LayoutIsVisible = false;
                if (list.Count == 0)
                {
                    list = await _gitHubDomainService.GetPullRequestsFromRepository(HubItem.pulls_formated_url);
                    this.ItensList = new ObservableCollection<PullRequestItem>(list);
                    OpeningText = $"{this.ItensList.Where(x => x.state == "open").Count()} opened";
                    ClosedText = $"{this.ItensList.Where(x => x.state == "close").Count()} closed";
                }
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
