using System;
using System.Collections.Generic;

namespace EventSourcing.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetTypeHierarchy(this Type target)
        {
            foreach (var @interface in target.GetInterfaces())
            {
                yield return @interface;
            }
            
            do
            {
                yield return target;

                target = target.BaseType;
            }
            while (target != null);
        }
    }
}