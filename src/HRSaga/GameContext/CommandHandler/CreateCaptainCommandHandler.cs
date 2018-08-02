using EventSourcing;
using HRSaga.GameContext.Aggregates;
using HRSaga.GameContext.Commands;

namespace HRSaga.GameContext.CommandHandler
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