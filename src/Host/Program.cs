using Autofac;
using EventSourcing;
using Host.Modules;
using HRSaga.UnknownContext.Aggregates;
using HRSaga.UnknownContext.Commands;
using HRSaga.UnknownContext.DomainEvents;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();

            var commandSender = container.Resolve<ICommandSender>();

            commandSender.Send(new CreateWorldCommand());
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
