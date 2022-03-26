using System;
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
            var builder = new ContainerBuilder();
            builder.RegisterType<Parent>();
            
            // builder.RegisterType<Child>().PropertiesAutowired();
            
            // builder.RegisterType<Child>()
            //     .WithProperty("Parent", new Parent());

            
            // builder.Register(c =>
            // {
            //     var child = new Child();
            //     child.SetParent(c.Resolve<Parent>());
            //     return child;
            // });

            builder.RegisterType<Child>()
                .OnActivated(e =>
                {
                    var p = e.Context.Resolve<Parent>();
                    e.Instance.SetParent(p);
                });

            var container = builder.Build();

            var parent = container.Resolve<Child>().Parent;
            Console.WriteLine(parent);
        }
    }
}