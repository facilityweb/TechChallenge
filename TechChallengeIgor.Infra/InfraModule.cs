using Autofac;
using TechChallengeIgor.Domain.Interfaces;
using TechChallengeIgor.Infra.Data;

namespace TechChallengeIgor.Infra
{
    public class InfraModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GitHubWebApi>().As<IGitHubWebApi>().InstancePerDependency();
            base.Load(builder);
        }
    }
}
