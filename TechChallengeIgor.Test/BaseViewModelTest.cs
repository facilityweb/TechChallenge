using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Exceptions;
using TechChallengeIgor.Domain.Interfaces;
using TechChallengeIgor.ViewModels;

namespace TechChallengeIgor.Test
{
    [TestClass]
    public class BaseViewModelTest
    {
        private readonly IContainer container;
        public BaseViewModelTest()
        {
            container = ContainerConfig.Configure();
        }
        [TestMethod]
        public void IsLoadingIsFalseAfterInicialization()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var viewModel = scope.Resolve<MainPageViewModel>();
                Assert.AreEqual(false, viewModel.IsLoading);
            }
        }
        [TestMethod]
        public void IsLoadingIsTrueWhenCallMethodLoading()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var viewModel = scope.Resolve<MainPageViewModel>();
                viewModel.LoadingOn();
                Assert.AreEqual(true, viewModel.IsLoading);
            }
        }
        [TestMethod]
        public void IsLoadingIsFalseWhenCallMethodLoading()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var viewModel = scope.Resolve<MainPageViewModel>();
                viewModel.LoadingOn();
                viewModel.LoadingOff();
                Assert.AreEqual(false, viewModel.IsLoading);
            }
        }
        [TestMethod]
        public void DefaultErrorMessageWhenError()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var domainService = new Mock<IGitHubDomainService>();
                domainService.Setup(x => x.GetGitHubMostPopularJavascriptRepositorys(999)).Throws(new Exception());
                var viewModel = scope.Resolve<MainPageViewModel>(new NamedParameter("gitHubDomainService", domainService.Object));
                viewModel.GetItens();
                Assert.AreEqual(true, viewModel.IsError);
                Assert.AreEqual(SystemInfra.DefaultMessage, viewModel.ErrorMessage);
            }
        }
        [TestMethod]
        public void CustomErrorMessageWhenError()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var domainService = new Mock<IGitHubDomainService>();
                domainService.Setup(x => x.GetGitHubMostPopularJavascriptRepositorys(999)).Throws(new NoConectivityException());
                var viewModel = scope.Resolve<MainPageViewModel>(new NamedParameter("gitHubDomainService", domainService.Object));
                viewModel.GetItens();
                Assert.AreEqual(true, viewModel.IsError);
                Assert.AreEqual(SystemInfra.NoConectivityErrorMessage, viewModel.ErrorMessage);
            }
        }
        [TestMethod]
        public void ChangeIsLoadingOfWhenWhenError()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var domainService = new Mock<IGitHubDomainService>();
                domainService.Setup(x => x.GetGitHubMostPopularJavascriptRepositorys(SystemInfra.MaxNumberOfRepositorys)).Throws(new NoConectivityException());
                var viewModel = scope.Resolve<MainPageViewModel>(new NamedParameter("gitHubDomainService", domainService.Object));
                viewModel.GetItens();
                Assert.AreEqual(false, viewModel.IsLoading);
            }
        }
    }
}
