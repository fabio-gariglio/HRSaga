using EventSourcing;

namespace HRSaga.UnknownContext.DomainEvents
{
    public class WizardCreatedDomainEvent : IEvent
    {
        public string WizardId { get; set; }
        public string WizardName { get; set; }
    }
}