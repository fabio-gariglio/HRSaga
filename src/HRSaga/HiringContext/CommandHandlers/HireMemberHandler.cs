using EventSourcing;
using HRSaga.HiringContext.Commands;

namespace HRSaga.HiringContext.CommandHandlers
{
    public class HireMemberHandler : ICommandHandler<HireMember>
    {
        public void Handle(HireMember command)
        {
            throw new System.NotImplementedException();
        }
    }
}