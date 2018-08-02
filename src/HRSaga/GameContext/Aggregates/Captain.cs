using System;
using EventSourcing;
using HRSaga.GameContext.DomainEvents;

namespace HRSaga.GameContext.Aggregates
{
    public class Captain : AggregateBase
    {
        public Captain()
        {
        }
        
        public Captain(string name)
        {          
            Apply(new CaptainCreatedDomainEvent
            {
                CaptainId = Guid.NewGuid().ToString(),
                CaptainName = name
            });
        }

        private void When(CaptainCreatedDomainEvent @event)
        {
            Id = @event.CaptainId;
        }
    }
}