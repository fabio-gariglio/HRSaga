using EventSourcing;

namespace HRSaga.GameContext.Commands
{
    public class CreateWorldCommand : ICommand
    {
        public int NumberOfWarriors { get; set; }
        public int NumberOfWizards { get; set; }
    }
}