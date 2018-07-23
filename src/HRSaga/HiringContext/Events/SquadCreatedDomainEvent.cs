using EventSourcing;

namespace HRSaga.HiringContext.Events
{
    public class SquadCreatedDomainEvent : IEvent
    {
        public string SquadId { get; set; }
        public string CaptainId { get; set; }
    }
}