using Autofac;
using EventSourcing;
using EventSourcing.Concrete;

namespace Host.Modules
{
    public class EventSourcingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();
            builder.RegisterType<CommandSender>().As<ICommandSender>().SingleInstance();
            builder.RegisterGeneric(typeof(InMemoryAggregateRepository<>)).As(typeof(IAggregateRepository<>)).SingleInstance();
        }
    }
}
