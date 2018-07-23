using System;
using EventSourcing;
using HRSaga.HiringContext.Events;

namespace HRSaga.HiringContext.Aggregates
{
    public class Squad : AggregateBase
    {
        public Squad()
        {
        }
        
        public Squad(string captainId)
        {
            Apply(new SquadCreatedDomainEvent
            {
                SquadId = Guid.NewGuid().ToString(),
                CaptainId = captainId
            });
        }

        private void When(SquadCreatedDomainEvent @event)
        {
            Id = @event.SquadId;
        }
    }
}