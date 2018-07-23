using Autofac;
using EventSourcing;
using Host.Modules;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();

            var commandSender = container.Resolve<ICommandSender>();
        }

        private static IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<EventSourcingModule>();
            containerBuilder.RegisterModule<HRSagaModule>();

            var containter = containerBuilder.Build();
            return containter;
        }
    }
}
