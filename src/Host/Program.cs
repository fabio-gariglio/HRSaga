using Autofac;
using Host.Modules;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();
            var game = container.Resolve<Game>();
            
            game.Start();
        }

        private static IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<EventSourcingModule>();
            containerBuilder.RegisterModule<HRSagaModule>();
            containerBuilder.RegisterModule<HostModule>();

            var containter = containerBuilder.Build();
            return containter;
        }
    }
}
