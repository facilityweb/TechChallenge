using Autofac;
using TechChallengeIgor.IOC;

namespace TechChallengeIgor.Test
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<TechChallengeModule>();
            return containerBuilder.Build();
        }
    }
}
