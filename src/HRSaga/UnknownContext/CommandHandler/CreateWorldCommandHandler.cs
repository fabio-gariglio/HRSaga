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
           
            Enumerable.Range(0, _random.Next(5, 10))
                .ToList()
                .ForEach(index => _commandSender.Send(new CreateWarriorCommand
                {
                    Name = $"warrior_{index}"
                }));
            
            Enumerable.Range(0, _random.Next(5, 10))
                .ToList()
                .ForEach(index => _commandSender.Send(new CreateWizardCommand()
                {
                    Name = $"wizard_{index}"
                }));            
        }
    }
}