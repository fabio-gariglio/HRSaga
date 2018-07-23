using System.Linq;

namespace EventSourcing.Concrete
{
    public class AggregateRepository<TAggregate> : IAggregateRepository<TAggregate>
        where TAggregate : IAggregate, new()
    {
        private readonly IEventStore _eventStore;

        public AggregateRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        
        public TAggregate GetById(string id)
        {
            var events = _eventStore.GetAllEvents(id).ToArray();
            if (!events.Any()) return default(TAggregate);
            
            var aggregate = new TAggregate();

            aggregate.Hydrates(events);
            
            return aggregate;
        }

        public void Save(TAggregate aggregate)
        {
            var events = aggregate.Flush();
            
            if (!events.Any()) return;;
            
            _eventStore.AppendEvents(events, aggregate.Id);
        }
    }
}