using System;

namespace EventSourcing
{
    public interface IEvent
    {
        string AggregateId { get; set; }
    }
}
