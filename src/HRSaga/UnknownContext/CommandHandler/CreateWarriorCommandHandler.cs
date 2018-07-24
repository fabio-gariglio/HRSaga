using EventSourcing;
using HRSaga.UnknownContext.Aggregates;
using HRSaga.UnknownContext.Commands;

namespace HRSaga.UnknownContext.CommandHandler
{
    public class CreateWarriorCommandHandler : ICommandHandler<CreateWarriorCommand>
    {
        private readonly IAggregateRepository<Warrior> _warriorRepository;

        public CreateWarriorCommandHandler(IAggregateRepository<Warrior> warriorRepository)
        {
            _warriorRepository = warriorRepository;
        }
        
        public void Handle(CreateWarriorCommand command)
        {
            var warrior = new Warrior(command.Name);
            
            _warriorRepository.Save(warrior);
        }
    }
}