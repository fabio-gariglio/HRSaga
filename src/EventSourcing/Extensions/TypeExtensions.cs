using System;
using System.Collections.Generic;
using System.Linq;

namespace EventSourcing.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetTypeHierarchy(this Type target)
        {
            return GetTypeHierarchyInternal(target).Distinct();
        }
        
        private static IEnumerable<Type> GetTypeHierarchyInternal(Type target)
        {
            foreach (var @interface in target.GetInterfaces())
            {
                yield return @interface;

                foreach (var type in GetTypeHierarchyInternal(@interface))
                {
                    yield return type;
                }
            }

            var baseType = target;

            do
            {
                yield return baseType;

                baseType = target.BaseType;
            }
            while (baseType != null);
        }
    }
}