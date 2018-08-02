using Autofac;
using EventSourcing;
using HRSaga;

namespace Host.Modules
{
    public class HostModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsClosedTypesOf(typeof(IEventHandler<>), "EventHandler");
            builder.RegisterType<InMemoryCaptainService>().As<ICaptainService>().SingleInstance();
            builder.RegisterType<InMemoryPopulationService>().As<IPopulationService>().SingleInstance();
            builder.RegisterType<Game>().SingleInstance();

        }
    }
}