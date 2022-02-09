using System;
using Autofac;

namespace autofac_scenario_without_di
{
  public interface ILog
  {
    void Write(string message);
  }

  public interface IConsole
  {
    
  }

  public class ConsoleLog : ILog, IConsole
  {
    public void Write(string message)
    {
      Console.WriteLine(message);
    }
  }

  public class EmailLog : ILog
  {
    const string adminEmail = "admin@foo.com";
    public void Write(string message)
    {
      Console.WriteLine($"Email sent to {adminEmail} : {message}");
    }
  }

  public class Engine
  {
    private ILog log;
    private int id;

    public Engine(ILog log)
    {
      this.log = log;
      id = new Random().Next();
    }

    public void Ahead(int power)
    {
      log.Write($"Engine [{id}] ahead {power}");
    }
  }

  public class Car
  {
    private Engine engine;
    private ILog log;

    public Car(Engine engine, ILog log)
    {
      this.engine = engine;
      this.log = log;
    }

    public void Go()
    {
      engine.Ahead(100);
      log.Write("Car going forward...");
    }
  }
  
  internal class Program
  {
    public static void Main(string[] args)
    {

      var builder = new ContainerBuilder();
      builder.RegisterType<EmailLog>()
        .As<ILog>()
        .As<IConsole>();
      builder.RegisterType<ConsoleLog>().As<ILog>().PreserveExistingDefaults();
      builder.RegisterType<Engine>();
      builder.RegisterType<Car>();

      IContainer container = builder.Build();
      var car = container.Resolve<Car>();
      car.Go();
    }
  }
}