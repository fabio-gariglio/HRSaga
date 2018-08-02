using System.Collections.Generic;
using EventSourcing.Extensions;

namespace EventSourcing
{
    public abstract class AggregateBase : IAggregate
    {
        public string Id { get; protected set; }
        public long Version { get; private set; }

        private readonly List<IEvent> _uncommittedEvents = new List<IEvent>();

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
                ApplyInternal(@event);
            }
        }

        protected void Apply(IEvent @event)
        {
            ApplyInternal(@event);
            
            _uncommittedEvents.Add(@event);
        }

        private void ApplyInternal(IEvent @event)
        {
            Version++;
            
            this.ApplyEvent(@event);
        }
    }
}