using System.Collections.Generic;

namespace EventSourcing
{
    public interface IAggregate
    {
        string Id { get; }
        long Version { get; }
        
        IEnumerable<IEvent> Flush();
        void Hydrates(IEnumerable<IEvent> events);
    }
}