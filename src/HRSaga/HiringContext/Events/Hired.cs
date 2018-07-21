
using EventSourcing;

namespace HRSaga.HiringContext.Events
{
    public class Hired : IEvent
    {
        public string AggregateId { get; set; }
    }
}