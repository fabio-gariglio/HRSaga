using System;
using Autofac;
using EventSourcing;
using Host.Modules;
using HRSaga.UnknownContext.Commands;

namespace Host
{
    class Program
    {
        static Random _random = new Random();
        
        static void Main(string[] args)
        {
            var container = CreateContainer();

            var commandSender = container.Resolve<ICommandSender>();

            commandSender.Send(new CreateWorldCommand
            {
                NumberOfWarriors = _random.Next(5, 10),
                NumberOfWizards = _random.Next(5, 10)
            });
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
