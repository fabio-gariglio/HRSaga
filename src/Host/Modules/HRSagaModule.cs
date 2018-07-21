using System.Reflection;
using Autofac;
using EventSourcing;
using EventSourcing.Autofac;
using HRSaga.UnknownContext.CaptainAggregate;
using Module = Autofac.Module;

namespace Host.Modules
{
    public class HRSagaModule : Module
    {
        private readonly Assembly _targetAssembly = typeof(Captain).Assembly;
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(_targetAssembly).AsClosedTypesOf(typeof(ICommandHandler<>));
        }
    }
}