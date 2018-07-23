using EventSourcing;

namespace HRSaga.UnknownContext.DomainEvents
{
    public class CaptainCreatedDomainEvent : IEvent
    {
        public string CaptainId { get; set; }
        public string CaptainName { get; set; }
    }
}