using EventSourcing;

namespace HRSaga.UnknownContext.Commands
{
    public class CreateWarriorCommand : ICommand
    {
        public string Name { get; set; }
    }
}