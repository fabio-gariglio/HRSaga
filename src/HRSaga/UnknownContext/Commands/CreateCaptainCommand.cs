using EventSourcing;

namespace HRSaga.UnknownContext.Commands
{
    public class CreateCaptainCommand : ICommand
    {
        public string Name { get; set; }
    }
}