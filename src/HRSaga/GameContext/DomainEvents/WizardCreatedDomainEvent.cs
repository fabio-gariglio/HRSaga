using EventSourcing;

namespace HRSaga.GameContext.DomainEvents
{
    public class WizardCreatedDomainEvent : IEvent
    {
        public string WizardId { get; set; }
        public string WizardName { get; set; }
    }
}