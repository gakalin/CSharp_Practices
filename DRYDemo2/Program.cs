// See https://aka.ms/new-console-template for more information

using DRYDemoLibrary;

Console.Write("What is your first name: ");
string firstName = Console.ReadLine();

Console.Write("What is your last name: ");
string lastName = Console.ReadLine();

EmployeeProcessor processor = new EmployeeProcessor();
string employeeID = processor.GenerateEmployeeID(firstName, lastName);

Console.WriteLine($"Your employee id is { employeeID }");

Console.ReadLine();
