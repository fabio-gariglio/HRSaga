using EventSourcing;
using HRSaga.UnknownContext.Commands;

namespace HRSaga.UnknownContext.CommandHandler
{
    public class CreateWorldCommandHandler : ICommandHandler<CreateWorldCommand>
    {
        private readonly ICommandSender _commandSender;

        public CreateWorldCommandHandler(ICommandSender commandSender)
        {
            _commandSender = commandSender;
        }
        
        public void Handle(CreateWorldCommand command)
        {
            _commandSender.Send(new CreateCaptainCommand
            {
                Name = "player-1"
            });
        }
    }
}