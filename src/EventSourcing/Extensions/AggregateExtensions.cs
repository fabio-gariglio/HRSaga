using System;
using System.Linq;
using System.Reflection;

namespace EventSourcing.Extensions
{
    public static class AggregateExtensions
    {
        public static void ApplyEvent(this IAggregate aggregate, IEvent @event)
        {
            var method = aggregate.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(m => HandlesEvents(m, @event.GetType()));
            
            if (method == null) return;

            method.Invoke(aggregate, new object[] {@event});
        }
        
        private static bool HandlesEvents(MethodBase methodInfo, Type eventType)
        {
            if (methodInfo.Name != "When") return false;

            var parameters = methodInfo.GetParameters();
            if (parameters.Length != 1) return false;

            var parameterType = parameters.First().ParameterType;
            
            return parameterType.IsAssignableFrom(eventType);
        }
    }
}