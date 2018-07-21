using EventSourcing;
using HRSaga.UnknownContext.CaptainAggregate;
using HRSaga.UnknownContext.Commands;

namespace HRSaga.UnknownContext.CommandHandlers
{
    public class CreateCaptainCommandHandler : ICommandHandler<CreateCaptainCommand>
    {
        private readonly IAggregateRepository<Captain> _captainRepository;

        public CreateCaptainCommandHandler(IAggregateRepository<Captain> captainRepository)
        {
            _captainRepository = captainRepository;
        }
        
        public void Handle(CreateCaptainCommand command)
        {
            var captain = new Captain(command.Name);
            
            _captainRepository.Save(captain);
        }
    }
}