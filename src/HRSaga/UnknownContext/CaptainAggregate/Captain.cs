using System;
using EventSourcing;
using HRSaga.UnknownContext.Events;

namespace HRSaga.UnknownContext.CaptainAggregate
{
    public class Captain : Aggregate
    {
        public Captain(string name)
        {
            Apply(new CaptainCreatedEvent
            {
                Id = Guid.NewGuid().ToString(),
                Name = name
            });
        }
    }
}