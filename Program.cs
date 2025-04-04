interface IEmployee{
     void DisplayDetails();
     double CalculateSalary();

}


abstract class Employee :  IEmployee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }

    public Employee(int id , string  name , string department)
    {
        Id = id;
        Name = name;
        Department = department; 

    }
    public abstract double CalculateSalary(); // Must be implemented by derived classes

    public virtual void DisplayDetails() // Can be overridden
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Department: {Department}");

    }


}



class PermanentEmployee : Employee 
{
    private double monthlySalary;

    public PermanentEmployee(int id, string name, string department, double salary)
        : base(id, name, department)
    {
        monthlySalary = salary;
    }
    public override double CalculateSalary() => monthlySalary;

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Salary: {monthlySalary:C}\n");
    }
}
class ContractEmployee : Employee
{
    private double hourlyRate;
    private int hoursWorked;

    public ContractEmployee(int id, string name, string department, double rate, int hours)
        : base(id, name, department)
    {
        hourlyRate = rate;
        hoursWorked = hours;
    }

    public override double CalculateSalary() => hourlyRate * hoursWorked;

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Hourly Rate: {hourlyRate:C}, Hours Worked: {hoursWorked}, Total Salary: {CalculateSalary():C}\n");
    }
}

// 4. Report Generator (Polymorphism Example)
class ReportGenerator
{
    public static void GenerateEmployeeReport(List<Employee> employees)
    {
        Console.WriteLine("\n--- Employee Report ---");
        foreach (var emp in employees)
        {
            emp.DisplayDetails();
        }
    }
}

// 5. Main Program
class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new PermanentEmployee(1, "Alice", "HR", 5000),
            new ContractEmployee(2, "Bob", "IT", 25, 160)
        };

        // Generate Report (Polymorphism in action)
        ReportGenerator.GenerateEmployeeReport(employees);
    }
}