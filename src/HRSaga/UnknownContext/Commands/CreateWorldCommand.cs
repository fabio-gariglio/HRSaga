using EventSourcing;

namespace HRSaga.UnknownContext.Commands
{
    public class CreateWorldCommand : ICommand
    {
        public int NumberOfWarriors { get; set; }
        public int NumberOfWizards { get; set; }
    }
}