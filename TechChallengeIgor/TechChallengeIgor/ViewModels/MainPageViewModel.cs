using System;
using System.Windows.Input;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Exceptions;
using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public override ICommand TryAgainCommand { get; set; }
        private readonly IGitHubDomainService _gitHubDomainService;
        public MainPageViewModel(IGitHubDomainService gitHubDomainService)
        {
            this._gitHubDomainService = gitHubDomainService;
        }
        public void GetItens()
        {
            try
            {
                LoadingOn();
                this._gitHubDomainService.GetGitHubMostPopularJavascriptRepositorys(SystemInfra.MaxNumberOfRepositorys);
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
