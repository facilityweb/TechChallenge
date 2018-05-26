using Autofac;
using TechChallengeIgor.Domain.Interfaces;
using TechChallengeIgor.IOC;

namespace TechChallengeIgor.Test
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ConnectivityInfomationTest>().As<IConnectivityInfomation>().InstancePerDependency();
            containerBuilder.RegisterModule<TechChallengeModule>();
            return containerBuilder.Build();
        }
    }
}
