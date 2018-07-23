using System.Collections.Generic;

namespace EventSourcing.Concrete
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly IDictionary<string, List<IEvent>> _eventStore = new Dictionary<string, List<IEvent>>();
        
        public void AppendEvents(IEnumerable<IEvent> events, string aggregateId)
        {
            var eventStream = GetEventStreamOrCreate(aggregateId);

            eventStream.AddRange(events);            
        }

        public IEnumerable<IEvent> GetAllEvents(string aggregateId)
        {
            var eventStream = GetEventStreamOrCreate(aggregateId);

            return eventStream;
        }

        private List<IEvent> GetEventStreamOrCreate(string aggregateId)
        {
            if (!_eventStore.TryGetValue(aggregateId, out var eventStream))
            {
                eventStream = new List<IEvent>();
                _eventStore.Add(aggregateId, eventStream);
            }

            return eventStream;
        }
    }
}