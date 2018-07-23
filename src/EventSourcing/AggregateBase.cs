using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EventSourcing
{
    public abstract class AggregateBase : IAggregate
    {
        public string Id { get; protected set; }

        private readonly List<IEvent> _uncommittedEvents;
        private readonly IDictionary<Type, MethodInfo> _methodByEventTypeMapping;

        protected AggregateBase()
        {
            _uncommittedEvents = new List<IEvent>();
            _methodByEventTypeMapping = GetMethodByEventTypeMapping();
        }

        public IEnumerable<IEvent> Flush()
        {
            var events = _uncommittedEvents.ToArray();

            _uncommittedEvents.Clear();
            
            return events;
        }
        
        public void Hydrates(IEnumerable<IEvent> events)
        {          
            foreach (var @event in events)
            {
                ApplyEvent(@event);
            }
        }

        protected void Apply(IEvent @event)
        {
            ApplyEvent(@event);
            _uncommittedEvents.Add(@event);
        }

        private void ApplyEvent(IEvent @event)
        {
            if(_methodByEventTypeMapping.TryGetValue(@event.GetType(), out var methodInfo))
            {
                methodInfo.Invoke(this, new object[] {@event});
            }
        }

        private IDictionary<Type, MethodInfo> GetMethodByEventTypeMapping()
        {
            var mapping = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(HandlesEvents)
                .ToDictionary(m => m.GetParameters().First().ParameterType, m => m);

            return mapping;
        }

        private static bool HandlesEvents(MethodInfo methodInfo)
        {
            if (methodInfo.Name != "When") return false;

            var parameters = methodInfo.GetParameters();

            return parameters.Length == 1;
        }
    }
}