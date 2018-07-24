using System;
using System.Linq;
using EventSourcing;
using HRSaga.UnknownContext.Commands;

namespace HRSaga.UnknownContext.CommandHandler
{
    public class CreateWorldCommandHandler : ICommandHandler<CreateWorldCommand>
    {
        private readonly ICommandSender _commandSender;
        private readonly Random _random;

        public CreateWorldCommandHandler(ICommandSender commandSender)
        {
            _commandSender = commandSender;
            _random = new Random();
        }
        
        public void Handle(CreateWorldCommand command)
        {
            _commandSender.Send(new CreateCaptainCommand
            {
                Name = "player-1"
            });

            for (var i = 0; i < command.NumberOfWarriors; i++)
            {
                _commandSender.Send(new CreateWarriorCommand {Name = $"warrior_{i}"});
            }
            
            for (var i = 0; i < command.NumberOfWizards; i++)
            {
                _commandSender.Send(new CreateWizardCommand {Name = $"wizard_{i}"});
            }
        }
    }
}