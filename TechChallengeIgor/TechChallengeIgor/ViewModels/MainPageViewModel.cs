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
        private List<HubItem> listResult;
        private string searchValue;
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
        public HubItem SelectedItem { get; set; }
        public override ICommand TryAgainCommand { get; set; }
        private readonly IGitHubDomainService _gitHubDomainService;
        public MainPageViewModel(IGitHubDomainService gitHubDomainService)
        {
            this._gitHubDomainService = gitHubDomainService;
            this.listResult = new List<HubItem>();
        }
        public async Task GetItensAsync()
        {
            try
            {
                LoadingOn();
                LayoutIsVisible = false;
                if (listResult.Count == 0)
                {
                    var model = await this._gitHubDomainService.GetGitHubMostPopularJavascriptRepositorys(SystemInfra.MaxNumberOfRepositorys);
                    listResult = model.items.ToList();
                }
                this.SearchItens(this.searchValue);
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
        public void SearchItens(string newTextValue)
        {
            searchValue = newTextValue;
            if (string.IsNullOrWhiteSpace(newTextValue))
                ItensList = new ObservableCollection<HubItem>(listResult);
            else
                ItensList = new ObservableCollection<HubItem>(listResult.Where(i => i.name.ToLower().Contains(searchValue.ToLower()) || i.owner.login.ToLower().Contains(searchValue.ToLower()))); ;
        }
    }
}
