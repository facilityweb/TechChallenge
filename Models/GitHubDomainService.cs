using System.Collections.Generic;
using System.Threading.Tasks;
using TechChallengeIgor.Domain.Exceptions;
using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.Domain
{
    public class GitHubDomainService : IGitHubDomainService
    {
        private readonly IGitHubWebApi _gitHubWebApi;
        private readonly IConnectivityInfomation _connectivityInfomation;
        public GitHubDomainService(IGitHubWebApi gitHubWebApi, IConnectivityInfomation connectivityInfomation)
        {
            this._gitHubWebApi = gitHubWebApi;
            this._connectivityInfomation = connectivityInfomation;
        }
        public Task<GitHubRespItem> GetGitHubMostPopularJavascriptRepositorys(int maxResults)
        {
            if (_connectivityInfomation.CheckConnection())
            {
                return this._gitHubWebApi.GetGitHubMostPopularJavascriptRepositorysAsync(maxResults);
            }
            else
                throw new NoConectivityException();
        }
        public Task<IList<PullRequestItem>> GetPullRequestsFromRepository(string url)
        {
            if (_connectivityInfomation.CheckConnection())
            {
                return this._gitHubWebApi.GetPullRequestsFromRepositoryAsync(url);
            }
            else
                throw new NoConectivityException();
        }
    }
}
