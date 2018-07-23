using Autofac;

namespace EventSourcing.Concrete
{
    public class CommandSender : ICommandSender
    {
        private readonly IComponentContext _componentContext;

        public CommandSender(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        
        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = _componentContext.Resolve<ICommandHandler<TCommand>>();
            
            commandHandler.Handle(command);
        }
    }
}
