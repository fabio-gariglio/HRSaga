
using EventSourcing;

namespace HRSaga.HiringContext.DomainEvent
{
    public class WarriorHiredDomainEvent : IEvent
    {
        public string SquadId { get; set; }
        public string WarriorId { get; set; }
    }
}