using System;

namespace EventSourcing
{
    public interface ICommand
    {
        string AggregateId { get; set; }
    }
}
