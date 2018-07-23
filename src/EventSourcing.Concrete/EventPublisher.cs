using System.Collections.Generic;
using Autofac;

namespace EventSourcing.Concrete
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IComponentContext _componentContext;

        public EventPublisher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlers = _componentContext.Resolve<IEnumerable<IEventHandler<TEvent>>>();

            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.Handle(@event);
            }
        }
    }
}
