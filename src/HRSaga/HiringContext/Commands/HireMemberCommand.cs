
using EventSourcing;

namespace HRSaga.HiringContext.Commands
{
    public class HireMemberCommand : ICommand
    {
        public string SquadId { get; set; }
        
        public string MemberId { get; set; }
    }
}