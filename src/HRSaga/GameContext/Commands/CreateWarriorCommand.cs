using EventSourcing;

namespace HRSaga.GameContext.Commands
{
    public class CreateWarriorCommand : ICommand
    {
        public string Name { get; set; }
    }
}