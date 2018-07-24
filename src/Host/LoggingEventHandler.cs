using System;
using EventSourcing;
using Newtonsoft.Json;

namespace Host
{
    public class LoggingEventHandler : IEventHandler<IEvent>
    {
        public void Handle(IEvent @event)
        {
            Console.WriteLine(@event.GetType().Name);
            Console.WriteLine(JsonConvert.SerializeObject(@event));
            Console.WriteLine();
        }
    }
}