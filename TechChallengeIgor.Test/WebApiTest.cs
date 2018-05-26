using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TechChallengeIgor.Domain;

namespace TechChallengeIgor.Test
{
    [TestClass]
    public class WebApiTest
    {
        private readonly IContainer container;
        public WebApiTest()
        {
            container = ContainerConfig.Configure();
        }
        [TestMethod]
        public async Task GetRepositoriesJsWebApiTestAsync()
        {
            var baseAddress = new Uri("https://api.github.com");

            using (var client = new HttpClient() { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Add("User-Agent", "TechChallengeIgor");
                var response = await client.GetAsync($"search/repositories?q=language:JavaScript&sort=stars&page=1&per_page=999");

                if (!response.IsSuccessStatusCode)
                    Assert.Fail();

                var json = await response.Content.ReadAsStringAsync();

                GitHubRespItem item = JsonConvert.DeserializeObject<GitHubRespItem>(await response.Content.ReadAsStringAsync());

                Assert.AreNotEqual(null, item);
            }
        }
        [TestMethod]
        public async Task GetPullRequestsJsWebApiTestAsync()
        {
            var baseAddress = new Uri("https://api.github.com");

            using (var client = new HttpClient() { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Add("User-Agent", "TechChallengeIgor");
                var response = await client.GetAsync($"repos/freeCodeCamp/freeCodeCamp/pulls");

                if (!response.IsSuccessStatusCode)
                    Assert.Fail();

                var json = await response.Content.ReadAsStringAsync();

                IList<PullRequestItem> itens = JsonConvert.DeserializeObject<IList<PullRequestItem>>(await response.Content.ReadAsStringAsync());

                Assert.AreNotEqual(0, itens.Count);
            }
        }
    }
}
