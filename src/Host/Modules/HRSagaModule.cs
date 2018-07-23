using System.Reflection;
using Autofac;
using EventSourcing;
using HRSaga.HiringContext.Aggregates;

namespace Host.Modules
{
    public class HRSagaModule : Autofac.Module
    {
        // TODO: Use more obvious type to reference HRSaga assembly
        private readonly Assembly _targetAssembly = typeof(Hireable).Assembly;
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_targetAssembly).AsClosedTypesOf(typeof(ICommandHandler<>));
            builder.RegisterAssemblyTypes(_targetAssembly).AsClosedTypesOf(typeof(IEventHandler<>));
        }
    }
}