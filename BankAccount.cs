using System;

// Class: represents a bank account with encapsulated data and controlled operations
class BankAccount{

    // Encapsulation: private fields are hidden from outside code
    // They can only be accessed or modified through the class's own methods
    private string accountNumber;
    private string accountHolderName;
    private double balance;

    // Constructor: initializes the account with an account number, holder name and starting balance
    // Called once when a BankAccount object is created
    public BankAccount(string accNo, string name, double initialBalance){
        accountNumber = accNo;
        accountHolderName = name;
        balance = initialBalance;
    }

    // Method: adds a valid amount to the account balance
    public void Deposit(double amount){
        // Guard clause: rejects zero or negative deposit amounts before proceeding
        if (amount <= 0){
            Console.WriteLine("Error: Cannot deposit negative or zero amount.");
            return; // Exits the method early without modifying the balance
        }
        balance += amount; // Increases balance by the deposited amount
        Console.WriteLine($"Deposited:{amount}");
    }

    // Method: deducts a valid amount from the account balance
    public void Withdraw(double amount){
        // Guard clause: rejects zero or negative withdrawal amounts
        if (amount <= 0){
            Console.WriteLine("Error: Invalid withdrawal amount.");
        }
        // Guard clause: prevents overdrawing by checking against current balance
        else if (amount > balance){
            Console.WriteLine("Error: Insufficient funds.");
        }
        else{
            balance -= amount; // Deducts the withdrawn amount from balance
            Console.WriteLine($"Withdrawn:{amount}");
        }
    }

    // Getter method: provides read-only access to the private balance field
    // Balance cannot be modified directly from outside the class
    public double GetBalance(){
        return balance;
    }

    // Getter method: provides read-only access to the private accountNumber field
    public string GetAccountNumber(){
        return accountNumber;
    }
}

// Test class: entry point that demonstrates the BankAccount class functionality
class BankAccountTest {
    static void Main(){
        // Creates a new BankAccount with account number "12345", holder "Emmanuel" and balance of 1000
        BankAccount acc = new BankAccount("12345", "Emmanuel", 1000);

        acc.Deposit(500);   // Valid deposit — balance becomes 1500
        acc.Deposit(-200);  // Invalid deposit — prints error, balance unchanged
        acc.Withdraw(200);  // Valid withdrawal — balance becomes 1300
        acc.Withdraw(2000); // Invalid withdrawal — insufficient funds, balance unchanged

        // Calls the getter method to retrieve and display the final balance
        Console.WriteLine("Balance: " + acc.GetBalance());
    }
}