using EventSourcing;
using HRSaga.UnknownContext.Aggregates;
using HRSaga.UnknownContext.Commands;

namespace HRSaga.UnknownContext.CommandHandler
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