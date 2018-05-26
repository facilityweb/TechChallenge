using Autofac;
using TechChallengeIgor.IOC;

namespace TechChallengeIgor
{
    public class AppSetup
    {
        private ContainerBuilder container;
        public AppSetup(ContainerBuilder container)
        {
            this.container = container;
        }
        public IContainer CreateContainer()
        {
            var containerBuilder = this.container == null ? new ContainerBuilder() : this.container;
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder container)
        {
            container.RegisterModule<TechChallengeModule>();
        }
    }
}
