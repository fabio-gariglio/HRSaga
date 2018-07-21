using EventSourcing;
using HRSaga.HiringContext.Commands;

namespace HRSaga.HiringContext.CommandHandlers
{
    public class RequestHiringHandler : ICommandHandler<RequestHiring>
    {
        public void Handle(RequestHiring command)
        {
            throw new System.NotImplementedException();
        }
    }
}