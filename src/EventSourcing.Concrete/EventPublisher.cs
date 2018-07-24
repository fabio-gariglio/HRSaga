using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using EventSourcing.Extensions;

namespace EventSourcing.Concrete
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IComponentContext _componentContext;
        private readonly MethodInfo _publishMethodInfo;
       
        public EventPublisher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
            _publishMethodInfo = GetType().GetMethod(nameof(PublishInternal), BindingFlags.Instance | BindingFlags.NonPublic);
        }
        
        public void Publish(IEvent @event)
        {
            var baseEventTypes = @event.GetType().GetTypeHierarchy().Where(typeof(IEvent).IsAssignableFrom);

            foreach (var eventType in baseEventTypes)
            {
                _publishMethodInfo.MakeGenericMethod(eventType).Invoke(this, new object [] {@event});    
            }
        }
        
        private void PublishInternal<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlers = _componentContext.ResolveKeyed<IEnumerable<IEventHandler<TEvent>>>("EventHandler");

            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.Handle(@event);
            }
        } 
    }
}
