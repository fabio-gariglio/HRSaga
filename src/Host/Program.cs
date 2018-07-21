using System;
using Autofac;
using Host.Modules;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<EventSourcingModule>();
            
            Console.WriteLine("Hello World!");
        }
    }
}
