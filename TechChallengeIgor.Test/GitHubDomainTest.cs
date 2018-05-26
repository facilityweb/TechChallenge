using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Exceptions;
using TechChallengeIgor.Domain.Interfaces;

namespace TechChallengeIgor.Test
{
    [TestClass]
    public class GitHubDomainTest
    {
        private readonly IContainer container;
        public GitHubDomainTest()
        {
            container = ContainerConfig.Configure();
        }
        [TestMethod]
        public async Task DomainServiceTestAsync()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var domainService = scope.Resolve<IGitHubDomainService>();
                var javascriptReps = await domainService.GetGitHubMostPopularJavascriptRepositorys(1);
                Assert.AreNotEqual(null, javascriptReps);
            }
        }

        [TestMethod]
        public async Task FormatUrlTestAsync()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var domainService = scope.Resolve<IGitHubDomainService>();
                var javascriptReps = await domainService.GetGitHubMostPopularJavascriptRepositorys(10);

                foreach (var item in javascriptReps.items)
                {
                    if (item.pulls_formated_url.Contains("{/number}"))
                        Assert.Fail();
                }
            }
        }

        [TestMethod]
        public async Task GetPullRequestsUrlFormatTest()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var domainService = scope.Resolve<IGitHubDomainService>();
                var javascriptReps = await domainService.GetGitHubMostPopularJavascriptRepositorys(12);

                var pullrequests = await domainService.GetPullRequestsFromRepository(javascriptReps.items[0].pulls_formated_url);
                if (pullrequests.Count == 0)
                    Assert.Fail();
            }
        }
        [TestMethod]
        public async Task NoConnectivityTestAsync()
        {
            var connecitvityMock = new Mock<IConnectivityInfomation>();
            connecitvityMock.Setup(x => x.CheckConnection()).Returns(false);
            using (var scope = container.BeginLifetimeScope())
            {
                try
                {
                    var webApiService = scope.Resolve<IGitHubWebApi>();
                    var domainService = new GitHubDomainService(webApiService, connecitvityMock.Object);

                    var javascriptReps = await domainService.GetGitHubMostPopularJavascriptRepositorys(1);
                    Assert.Fail();
                }
                catch (NoConectivityException)
                {
                    // Success
                }
            }
        }
        [TestMethod]
        public async Task ConnectivityTestAsync()
        {
            var connecitvityMock = new Mock<IConnectivityInfomation>();
            connecitvityMock.Setup(x => x.CheckConnection()).Returns(true);
            using (var scope = container.BeginLifetimeScope())
            {
                try
                {
                    var webApiService = scope.Resolve<IGitHubWebApi>();
                    var domainService = new GitHubDomainService(webApiService, connecitvityMock.Object);
                    var javascriptReps = await domainService.GetGitHubMostPopularJavascriptRepositorys(1);
                }
                catch (NoConectivityException)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
