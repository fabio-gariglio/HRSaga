using System;
using EventSourcing;

namespace Host
{
    public class LoggingEventHandler : IEventHandler<IEvent>
    {
        public void Handle(IEvent @event)
        {
            Console.WriteLine(@event.GetType().Name);
        }
    }
}