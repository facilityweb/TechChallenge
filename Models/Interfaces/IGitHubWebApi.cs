using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechChallengeIgor.Domain.Interfaces
{
    public interface IGitHubWebApi
    {
        Task<GitHubRespItem> GetGitHubMostPopularJavascriptRepositorysAsync(int maxResults);
        Task<IList<PullRequestItem>> GetPullRequestsFromRepositoryAsync(string url);
    }
}
