using EventSourcing;
using HRSaga.HiringContext.Events;

namespace HRSaga.HiringContext.EventHandlers
{
    public class HiredHandler : IEventHandler<Hired>
    {
        public void Handle(Hired @event)
        {
            throw new System.NotImplementedException();
        }
    }
}