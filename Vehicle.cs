// Base class: defines shared properties and behaviour for all vehicle types
class Vehicle
{
    // Protected field: accessible by this class and any derived classes
    // but hidden from outside code (encapsulation)
    protected string brand;

    // Constructor: initializes the brand when a Vehicle object is created
    public Vehicle(string brand)
    {
        this.brand = brand;
    }

    // Virtual method: provides a default engine start behaviour
    // Can be overridden by derived classes to provide specific implementations
    public virtual void StartEngine()
    {
        Console.WriteLine("Vehicle engine starting...");
    }
}

// Derived class: inherits from Vehicle and represents a car
// Gets all properties and methods of Vehicle plus its own overrides
class Car : Vehicle
{
    // Constructor: passes the brand value up to the base class constructor
    public Car(string brand) : base(brand) { }

    // Method overriding: replaces the base class StartEngine with car-specific logic
    public override void StartEngine()
    {
        // base keyword: explicitly calls the parent class StartEngine first
        // ensures the shared behaviour runs before the car-specific behaviour
        base.StartEngine();
        Console.WriteLine("Car engine started.");
    }
}

// Derived class: inherits from Vehicle and represents a motorcycle
class Motorcycle : Vehicle
{
    // Constructor: passes the brand value up to the base class constructor
    public Motorcycle(string brand) : base(brand) { }

    // Method overriding: replaces the base class StartEngine with motorcycle-specific logic
    public override void StartEngine()
    {
        // base keyword: calls the parent StartEngine before the motorcycle-specific behaviour
        base.StartEngine();
        Console.WriteLine("Motorcycle engine started.");
    }
}

// Test class: entry point that demonstrates inheritance and method overriding
class VehicleTest{
    static void Main(){
        // Polymorphism: both objects are declared as the base type Vehicle
        // but hold instances of their respective derived classes
        Vehicle v1 = new Car("Toyota");       // Car object stored as Vehicle type
        Vehicle v2 = new Motorcycle("Yamaha"); // Motorcycle object stored as Vehicle type

        // At runtime, C# calls the correct overridden StartEngine method
        // for each object based on its actual type — not its declared type
        v1.StartEngine(); // Calls Car's StartEngine
        v2.StartEngine(); // Calls Motorcycle's StartEngine
    }
}