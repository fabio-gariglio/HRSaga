using EventSourcing;

namespace HRSaga.UnknownContext.DomainEvents
{
    public class WarriorCreatedDomainEvent : IEvent
    {
        public string WarriorId { get; set; }
        public string WarriorName { get; set; }
    }
}