using System.Collections.Generic;

namespace EventSourcing.Concrete
{
    public interface IEventStore
    {
        IEnumerable<IEvent> GetAllEvents(string aggregateId);
        void AppendEvents(IEnumerable<IEvent> events, string aggregateId);
    }
}