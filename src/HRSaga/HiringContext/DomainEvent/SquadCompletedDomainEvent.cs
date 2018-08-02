using EventSourcing;

namespace HRSaga.HiringContext.DomainEvent
{
    public class SquadCompletedDomainEvent : IEvent
    {
        public string SquadId { get; set; }
    }
}