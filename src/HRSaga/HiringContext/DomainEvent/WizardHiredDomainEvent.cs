
using EventSourcing;

namespace HRSaga.HiringContext.DomainEvent
{
    public class WizardHiredDomainEvent : IEvent
    {
        public string SquadId { get; set; }
        public string WizardId { get; set; }
    }
}