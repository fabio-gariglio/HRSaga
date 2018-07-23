using System.Collections.Generic;

namespace EventSourcing
{
    public interface IAggregate
    {
        string Id { get; }
        IEnumerable<IEvent> Flush();
        void Hydrates(IEnumerable<IEvent> events);
    }
    
    public abstract class AggregateBase : IAggregate
    {
        private readonly List<IEvent> _uncommittedEvents = new List<IEvent>();
        
        public string Id { get; protected set; }      

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
            var whenMethod = GetType().GetMethod("When", new[] {@event.GetType()});
            if (whenMethod == null) return;

            whenMethod.Invoke(this, new object[] {@event});
        }
    }
}