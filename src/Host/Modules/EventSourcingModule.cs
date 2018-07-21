using Autofac;
using EventSourcing;
using EventSourcing.Autofac;

namespace Host.Modules
{
    public class EventSourcingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandSender>().As<ICommand>().SingleInstance();
        }
    }
}