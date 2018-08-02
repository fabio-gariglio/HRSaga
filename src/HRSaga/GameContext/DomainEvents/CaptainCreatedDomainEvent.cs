using EventSourcing;

namespace HRSaga.GameContext.DomainEvents
{
    public class CaptainCreatedDomainEvent : IEvent
    {
        public string CaptainId { get; set; }
        public string CaptainName { get; set; }
    }
}