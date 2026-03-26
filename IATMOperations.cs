// Interface defines a contract that any implementing class must follow
// It specifies what operations an ATM must support, without providing any implementation
interface IATMOperations
{
    void Withdraw(double amount);  // Must support withdrawing funds
    void Deposit(double amount);   // Must support depositing funds
    void CheckBalance();           // Must support checking current balance
}

// BankATM implements IATMOperations, providing concrete logic for each ATM operation
// The class must implement all methods defined in the interface
class BankATM : IATMOperations
{
    // Private field: balance is hidden from outside access (encapsulation)
    // Only the methods within this class can read or modify it
    private double balance = 1000; // Starting balance is 1000

    // Withdraw: deducts amount from balance if sufficient funds exist
    public void Withdraw(double amount)
    {
        // Guard clause: prevents overdraft by checking balance before deducting
        if (amount > balance)
            Console.WriteLine("Insufficient funds.");
        else
        {
            balance -= amount; // Deduct the withdrawn amount from balance
            Console.WriteLine($"Withdrawn: {amount}");
        }
    }

    // Deposit: adds amount to balance if the deposit value is valid
    public void Deposit(double amount)
    {
        // Guard clause: rejects zero or negative deposit amounts
        if (amount <= 0)
            Console.WriteLine("Invalid deposit.");
        else
        {
            balance += amount; // Add the deposited amount to balance
            Console.WriteLine($"Deposited: {amount}");
        }
    }

    // CheckBalance: displays the current account balance to the user
    public void CheckBalance()
    {
        Console.WriteLine($"Balance: {balance}");
    }
}

// Test class: entry point that demonstrates the ATM operations
class IATMOperationsTest
{
    static void Main()
    {
        // Create an instance of BankATM
        // atm is declared as BankATM giving access to all implemented interface methods
        BankATM atm = new BankATM();

        atm.Deposit(200);    // Deposits 200 — balance becomes 1200
        atm.Withdraw(500);   // Withdraws 500 — balance becomes 700
        atm.CheckBalance();  // Prints current balance: 700
    }
}