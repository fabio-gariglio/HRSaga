using EventSourcing;

namespace HRSaga.GameContext.Commands
{
    public class CreateWizardCommand : ICommand
    {
        public string Name { get; set; }
    }
}