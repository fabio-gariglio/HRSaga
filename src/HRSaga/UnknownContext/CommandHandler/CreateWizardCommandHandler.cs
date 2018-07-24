using EventSourcing;
using HRSaga.UnknownContext.Aggregates;
using HRSaga.UnknownContext.Commands;

namespace HRSaga.UnknownContext.CommandHandler
{
    public class CreateWizardCommandHandler : ICommandHandler<CreateWizardCommand>
    {
        private readonly IAggregateRepository<Wizard> _wizardRepository;

        public CreateWizardCommandHandler(IAggregateRepository<Wizard> wizardRepository)
        {
            _wizardRepository = wizardRepository;
        }
        
        public void Handle(CreateWizardCommand command)
        {
            var wizard = new Wizard(command.Name);
            
            _wizardRepository.Save(wizard);
        }
    }
}