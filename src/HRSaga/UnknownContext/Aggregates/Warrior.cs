using System;
using EventSourcing;
using HRSaga.UnknownContext.DomainEvents;

namespace HRSaga.UnknownContext.Aggregates
{
    public class Warrior : AggregateBase
    {
        public Warrior()
        {
        }
        
        public Warrior(string name)
        {          
            Apply(new WarriorCreatedDomainEvent
            {
                WarriorId = Guid.NewGuid().ToString(),
                WarriorName = name
            });
        }

        private void When(WarriorCreatedDomainEvent @event)
        {
            Id = @event.WarriorId;
        }
    }
}