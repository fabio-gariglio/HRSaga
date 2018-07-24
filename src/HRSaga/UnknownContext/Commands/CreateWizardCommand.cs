using EventSourcing;

namespace HRSaga.UnknownContext.Commands
{
    public class CreateWizardCommand : ICommand
    {
        public string Name { get; set; }
    }
}