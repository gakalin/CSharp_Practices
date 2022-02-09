using System;

namespace autofac_scenario_without_di
{
  public interface ILog
  {
    void Write(string message);
  }

  public class ConsoleLog : ILog
  {
    public void Write(string message)
    {
      Console.WriteLine(message);
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
      var log = new ConsoleLog();
      var engine = new Engine(log);
      var car = new Car(engine, log);
      car.Go();
    }
  }
}