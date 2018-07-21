using System.Collections.Generic;

namespace EventSourcing
{
    public abstract class Aggregate
    {      
        public string Id { get; set; }
        public List<IEvent> UncommittedEvents = new List<IEvent>();   

        protected void Apply(IEvent @event)
        {
            UncommittedEvents.Add(@event);
        }
    }
}