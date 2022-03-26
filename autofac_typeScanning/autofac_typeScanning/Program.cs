using System;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace autofac_propertyMethodInjection
{
    internal class Program
    {
        public class Parent
        {
            public override string ToString()
            {
                return "I am your father";
            }
        }

        public class Child
        {
            public string Name { get; set; }
            public Parent Parent { get; set; }

            public void SetParent(Parent parent)
            {
                Parent = parent;
            }
        }
        
        public static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Log"))
                .Except<SMSLog>()
                .Except<ConsoleLog>(c => c.As<ILog>().SingleInstance())
                .AsSelf();

            builder.RegisterAssemblyTypes(assembly)
                .Except<SMSLog>()
                .Where(t => t.Name.EndsWith("Log"))
                .As(t => t.GetInferfaces()[0]);
        }
    }
}