using System;
using EventSourcing;
using HRSaga.GameContext.DomainEvents;

namespace HRSaga.GameContext.Aggregates
{
    public class Wizard : AggregateBase
    {
        public Wizard()
        {
        }
        
        public Wizard(string name)
        {          
            Apply(new WizardCreatedDomainEvent
            {
                WizardId = Guid.NewGuid().ToString(),
                WizardName = name
            });
        }

        private void When(WizardCreatedDomainEvent @event)
        {
            Id = @event.WizardId;
        }
    }
}