using EventSourcing;

namespace HRSaga.HiringContext.DomainEvent
{
    public class SquadCreatedDomainEvent : IEvent
    {
        public string SquadId { get; set; }
        public string CaptainId { get; set; }
    }
}