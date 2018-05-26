using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.Infra.Data
{
    public class GitHubWebApi : IGitHubWebApi
    {
        private const string baseUrl = "https://api.github.com";
        public async Task<GitHubRespItem> GetGitHubMostPopularJavascriptRepositorysAsync(int maxResults)
        {
            var baseAddress = new Uri(baseUrl);

            using (var client = new HttpClient() { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Add("User-Agent", "TechChallengeIgor");
                var response = await client.GetAsync($"search/repositories?q=language:JavaScript&sort=stars&page=1&per_page={maxResults}");

                //if (!response.IsSuccessStatusCode)
                //    throw new System.Exception();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GitHubRespItem>(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<IList<PullRequestItem>> GetPullRequestsFromRepositoryAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "TechChallengeIgor");
                var response = await client.GetAsync(url);

                //if (!response.IsSuccessStatusCode)
                //    Assert.Fail();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IList<PullRequestItem>>(await response.Content.ReadAsStringAsync());

                //Assert.AreNotEqual(0, itens.Count);
            }
        }
    }
}
