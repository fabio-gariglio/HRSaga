
using EventSourcing;

namespace HRSaga.HiringContext.Commands
{
    public class RequestHiring : ICommand
    {
        public string AggregateId { get; set; }
    }
}