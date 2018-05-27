using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Interfaces;
using TechChallengeIgor.ViewModels;

namespace TechChallengeIgor.Test
{
    [TestClass]
    public class SearchResultsTest
    {
        private readonly IContainer container;
        public SearchResultsTest()
        {
            container = ContainerConfig.Configure();
        }
        [TestMethod]
        public async Task TestMethod1Async()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var domainService = new Mock<IGitHubDomainService>();

                domainService.Setup(x => x.GetGitHubMostPopularJavascriptRepositorys(999))
                    .Returns(Task.FromResult(new GitHubRespItem()
                    {
                        total_count = 10,
                        items = new List<HubItem> {
                        new HubItem() { name ="freeCodeCamp",owner = new Owner(){login="freeCodeCamp" } },
                        new HubItem() { name ="angular",owner = new Owner(){login="Roland Running" } },
                        new HubItem() { name ="react",owner = new Owner(){login="facebook" } },
                        new HubItem() { name ="vue",owner = new Owner(){login="Sona Garica" } },
                        new HubItem() { name ="d3",owner = new Owner(){login="Tess Brooker" } },
                        new HubItem() { name ="javascript",owner = new Owner(){login="Lashaunda Rodriques" } },
                        new HubItem() { name ="facebook",owner = new Owner(){login="Hong Nickels" } },
                        new HubItem() { name ="react-native",owner = new Owner(){login="Dino Mitcham" } }
                        }
                    }));
                var viewModel = scope.Resolve<MainPageViewModel>(new NamedParameter("gitHubDomainService", domainService.Object));
                await viewModel.GetItensAsync();
                Assert.AreNotEqual(0, viewModel.ItensList.Count);

                viewModel.SearchItens("freeCodeCamp");
                Assert.AreEqual(1, viewModel.ItensList.Count);
                viewModel.SearchItens("Roland");
                Assert.AreEqual(1, viewModel.ItensList.Count);
                viewModel.SearchItens("facebook");
                Assert.AreEqual(2, viewModel.ItensList.Count);
                //test UPPER results
                viewModel.SearchItens("FACEBOOK");
                Assert.AreEqual(2, viewModel.ItensList.Count);
                viewModel.SearchItens("VUE");
                Assert.AreEqual(1, viewModel.ItensList.Count);
            }
        }
    }
}
