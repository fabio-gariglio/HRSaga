
using EventSourcing;

namespace HRSaga.HiringContext.Commands
{
    public class HireMember : ICommand
    {
        public string AggregateId { get; set; }
    }
}