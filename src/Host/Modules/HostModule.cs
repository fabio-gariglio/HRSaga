using Autofac;
using EventSourcing;

namespace Host.Modules
{
    public class HostModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsClosedTypesOf(typeof(IEventHandler<>), "EventHandler");
        }
    }
}