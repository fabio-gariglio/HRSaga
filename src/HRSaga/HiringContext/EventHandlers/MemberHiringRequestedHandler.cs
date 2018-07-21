using EventSourcing;
using HRSaga.HiringContext.Events;

namespace HRSaga.HiringContext.EventHandlers
{
    public class MemberHiringRequestedHandler : IEventHandler<MemberHiringRequested>
    {
        public void Handle(MemberHiringRequested @event)
        {
            throw new System.NotImplementedException();
        }
    }
}