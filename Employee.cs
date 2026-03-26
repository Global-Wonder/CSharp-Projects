// Base class (Superclass): defines shared properties and behaviour for all employee types
class Employee
{
    // Protected fields: accessible by this class and any derived classes
    // but hidden from outside code (encapsulation)
    protected string name;
    protected double salary;

    // Constructor: initializes name and salary when an Employee object is created
    public Employee(string name, double salary)
    {
        this.name = name;
        this.salary = salary;
    }

    // Virtual method: provides a default annual salary calculation
    // Can be overridden by derived classes to provide their own specific calculation
    public virtual double CalculateAnnualSalary()
    {
        return salary * 12; // Default: monthly salary multiplied by 12 months
    }
}

// Derived class: inherits from Employee and represents a full-time employee
// Extends the base class by adding a bonus field
class FullTimeEmployee : Employee
{
    private double bonus; // Additional field specific to full-time employees

    // Constructor: accepts name, salary and bonus
    // base() passes name and salary up to the Employee base class constructor
    public FullTimeEmployee(string name, double salary, double bonus)
        : base(name, salary) // Calls base class constructor
    {
        this.bonus = bonus;
    }

    // Polymorphism: overrides the base method with full-time employee salary logic
    // Annual salary includes the monthly salary times 12 plus a one-time bonus
    public override double CalculateAnnualSalary()
    {
        return (salary * 12) + bonus;
    }
}

// Derived class: inherits from Employee and represents a part-time employee
// Uses hours worked and hourly rate instead of a fixed monthly salary
class PartTimeEmployee : Employee
{
    private int hoursWorked;    // Number of hours worked per month
    private double hourlyRate;  // Pay rate per hour

    // Constructor: accepts name, hours worked and hourly rate
    // Passes 0 as salary to base class since part-time pay is calculated differently
    public PartTimeEmployee(string name, int hours, double rate)
        : base(name, 0) // Salary not used directly here
    {
        hoursWorked = hours;
        hourlyRate = rate;
    }

    // Polymorphism: overrides the base method with part-time employee salary logic
    // Annual salary is calculated as hours worked multiplied by hourly rate times 12 months
    public override double CalculateAnnualSalary()
    {
        return hoursWorked * hourlyRate * 12;
    }
}

// Test class: entry point that demonstrates inheritance and polymorphism
class EmployeeTest{
    static void Main(){
        // Creates a full-time employee with a monthly salary of 2000 and a bonus of 5000
        FullTimeEmployee f = new FullTimeEmployee("Ama", 2000, 5000);

        // Creates a part-time employee working 80 hours at 15 per hour
        PartTimeEmployee p = new PartTimeEmployee("Kofi", 80, 15);

        // Displays a formatted annual salary report for both employees
        Console.WriteLine("===== Annual Salary Report =====");
        Console.WriteLine($"Full-Time Employee : Ama");
        Console.WriteLine($"  Base Salary      : GHS 2,000.00/month");
        Console.WriteLine($"  Bonus            : GHS 5,000.00/month");
        // Calls FullTimeEmployee's overridden CalculateAnnualSalary at runtime
        Console.WriteLine($"  Annual Salary    : GHS {f.CalculateAnnualSalary():N2}");
        Console.WriteLine();
        Console.WriteLine($"Part-Time Employee : Kofi");
        Console.WriteLine($"  Hours Per Week   : 80 hrs");
        Console.WriteLine($"  Hourly Rate      : GHS 15.00/hr");
        // Calls PartTimeEmployee's overridden CalculateAnnualSalary at runtime
        Console.WriteLine($"  Annual Salary    : GHS {p.CalculateAnnualSalary():N2}");
    }
}
