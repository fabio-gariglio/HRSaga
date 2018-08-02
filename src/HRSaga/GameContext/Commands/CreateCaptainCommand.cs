using EventSourcing;

namespace HRSaga.GameContext.Commands
{
    public class CreateCaptainCommand : ICommand
    {
        public string Name { get; set; }
    }
}