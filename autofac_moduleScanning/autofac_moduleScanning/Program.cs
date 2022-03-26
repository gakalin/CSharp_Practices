using System;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Module = Autofac.Module;

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

        public class ParentChildModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<Parent>();
                builder.Register(c => new Child() {Parent = c.Resolve<Parent>()});
                
            }
        }
        
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(Program).Assembly);
            // builder.RegisterAssemblyModules<ParentChildModule>(typeof(Program).Assembly);
            var container = builder.Build();
            Console.WriteLine(container.Resolve<Child>().Parent);
        }
    }
}