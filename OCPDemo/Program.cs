using OCPLibrary;

List<IApplicantModel> applicants = new List<IApplicantModel>
{
    new PersonModel { FirstName = "Gokberk", LastName = "Akalin"},
    new ManagerModel { FirstName = "Test", LastName = "User" },
    new ExecutiveModel { FirstName = "Erdem", LastName = "Akalın"}
};

List<EmployeeModel> employees = new List<EmployeeModel>();

foreach (var person in applicants)
{
    employees.Add(person.AccountProcessor.Create(person));
}

foreach (var emp in employees)
{
    Console.WriteLine($"{ emp.FirstName } { emp.LastName }: { emp.EmailAddress } IsManager: { emp.IsManager } IsExecutive: { emp.IsExecutive}");
}

Console.ReadLine();
