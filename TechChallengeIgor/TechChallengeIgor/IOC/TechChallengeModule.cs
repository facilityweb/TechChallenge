using Autofac;
using TechChallengeIgor.Domain;
using TechChallengeIgor.Domain.Interfaces;
using TechChallengeIgor.Infra;

namespace TechChallengeIgor.IOC
{
    public  class TechChallengeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GitHubDomainService>().As<IGitHubDomainService>().InstancePerDependency();
            builder.RegisterModule<InfraModule>();
            base.Load(builder);
        }
    }
}
