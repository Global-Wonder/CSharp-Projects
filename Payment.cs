using System;
using System.Collections.Generic;

// Abstract class: defines a common blueprint for all payment types
// Cannot be instantiated directly — must be inherited by a concrete class
abstract class Payment
{
    // Abstract method: enforces that every subclass must provide
    // its own specific implementation of how a payment is processed
    public abstract void ProcessPayment(double amount);
}

// Concrete subclass: represents a credit card payment method
// Inherits from Payment and provides its own implementation of ProcessPayment
class CreditCardPayment : Payment
{
    // Overrides the abstract method with credit card-specific payment logic
    public override void ProcessPayment(double amount)
    {
        Console.WriteLine($"Paid {amount} using Credit Card.");
    }
}

// Concrete subclass: represents a mobile money payment method
class MobileMoneyPayment : Payment
{
    // Overrides the abstract method with mobile money-specific payment logic
    public override void ProcessPayment(double amount)
    {
        Console.WriteLine($"Paid {amount} using Mobile Money.");
    }
}

// Concrete subclass: represents a bank transfer payment method
class BankTransferPayment : Payment
{
    // Overrides the abstract method with bank transfer-specific payment logic
    public override void ProcessPayment(double amount)
    {
        Console.WriteLine($"Paid {amount} via Bank Transfer.");
    }
}

// Test class: entry point that demonstrates polymorphism across payment types
class PaymentTest{
    static void Main()
    {
        // Polymorphism: all three different payment objects are stored
        // under the same base type Payment in a single list
        List<Payment> payments = new List<Payment>()
        {
            new CreditCardPayment(),   // Credit card payment object
            new MobileMoneyPayment(),  // Mobile money payment object
            new BankTransferPayment()  // Bank transfer payment object
        };
        
        // Iterates through each payment object in the list
        // At runtime, C# automatically calls the correct subclass implementation
        // of ProcessPayment — this is runtime polymorphism in action
        foreach (Payment p in payments)
        {
            p.ProcessPayment(100); // Each object processes a payment of 100
        }

    }
}