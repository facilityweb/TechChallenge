using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechChallengeIgor.Domain.Interfaces
{
    public interface IGitHubDomainService
    {
        Task<GitHubRespItem> GetGitHubMostPopularJavascriptRepositorys(int maxResults);
        Task<IList<PullRequestItem>> GetPullRequestsFromRepository(string url);
    }
}
