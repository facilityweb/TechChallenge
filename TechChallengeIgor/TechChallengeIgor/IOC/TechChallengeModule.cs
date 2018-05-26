using Autofac;
using TechChallengeIgor.Infra;

namespace TechChallengeIgor.IOC
{
    public  class TechChallengeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<InfraModule>();
            base.Load(builder);
        }
    }
}
