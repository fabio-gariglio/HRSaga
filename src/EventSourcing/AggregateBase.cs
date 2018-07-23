using System.Collections.Generic;
using EventSourcing.Extensions;

namespace EventSourcing
{
    public abstract class AggregateBase : IAggregate
    {
        public string Id { get; protected set; }

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
                this.ApplyEvent(@event);
            }
        }

        protected void Apply(IEvent @event)
        {
            this.ApplyEvent(@event);
            
            _uncommittedEvents.Add(@event);
        }
    }
}