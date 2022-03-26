
using System;
using Autofac;

namespace autofac__delegateFactories
{
  internal class Program
  {

    public class Service
    {
      public string DoSomething(int value)
      {
        return $"I have {value}";
      }
    }

    public class DomainObject
    {
      private Service service;
      private int value;

      public delegate DomainObject Factory(int value);

      public DomainObject(Service service, int value)
      {
        this.service = service;
        this.value = value;
      }

      public override string ToString()
      {
        return service.DoSomething(value);
      }
    }
    public static void Main(string[] args)
    {
      var cb = new ContainerBuilder();
      cb.RegisterType<Service>();
      cb.RegisterType<DomainObject>();

      var container = cb.Build();
      var dobj = container.Resolve<DomainObject>(
        new PositionalParameter(1, 42));
      Console.WriteLine(dobj);

      var factory = container.Resolve<DomainObject.Factory>();
      var dobj2 = factory(43);
      Console.WriteLine(dobj2);
    }
  }
}