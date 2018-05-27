using Autofac;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Interfaces;
using TechChallengeIgor.Infra;
using TechChallengeIgor.ViewModels;

namespace TechChallengeIgor.IOC
{
    public  class TechChallengeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GitHubDomainService>().As<IGitHubDomainService>().InstancePerDependency();
            builder.RegisterModule<InfraModule>();
            builder.RegisterType<MainPageViewModel>().InstancePerDependency();
            builder.RegisterType<PullRequestsPageViewModel>().InstancePerDependency();
            builder.RegisterType<PullRequestDetailPageViewModel>().InstancePerDependency();            
            base.Load(builder);
        }
    }
}
