using System;
using Autofac;
using EventSourcing;
using Host.Modules;
using HRSaga.UnknownContext.Commands;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CreateContainer();

            var commandSender = container.Resolve<ICommandSender>();
            commandSender.Send(new CreateCaptainCommand
            {
                Name = "Player-1"
            });
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
