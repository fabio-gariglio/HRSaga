
using EventSourcing;

namespace HRSaga.HiringContext.Events
{
    public class MemberHiringRequested : IEvent
    {
        public string AggregateId { get; set; }
    }
}