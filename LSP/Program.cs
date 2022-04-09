using DemoLibrary;

IManager accountingVP = new Manager();
accountingVP.FirstName = "Gokberk";
accountingVP.LastName = "Akalin";
accountingVP.CalculatePerHourRate(4);

IManaged emp = new Manager();

emp.FirstName = "Erdem";
emp.LastName = "Akalin";
emp.AssignManager(accountingVP);
emp.CalculatePerHourRate(2);

Console.WriteLine($"{ emp.FirstName }'s salary is ${ emp.Salary }/hour");

Console.ReadLine();