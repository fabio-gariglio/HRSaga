using System.Reflection;
using Autofac;
using EventSourcing;
using HRSaga.UnknownContext.CaptainAggregate;

namespace Host.Modules
{
    public class HRSagaModule : Autofac.Module
    {
        private readonly Assembly _targetAssembly = typeof(Captain).Assembly;
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_targetAssembly).AsClosedTypesOf(typeof(ICommandHandler<>));
            builder.RegisterAssemblyTypes(_targetAssembly).AsClosedTypesOf(typeof(IEventHandler<>));
        }
    }
}