using System;

class BankAccount
{
    // Field 
    private double balance;

    // Constructor
    public BankAccount(double initialBal)
    {
        balance = initialBal;
    }

    // Methods
    public void Deposit(double amount)
    {

        // Conditional Statements - if else
        if (amount > 0)
        {
            balance = balance + amount;
            Console.WriteLine("Amount deposited.");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance = balance - amount;
            Console.WriteLine("Amount withdrawn.");
        }
        else
        {
            Console.WriteLine("Invalid or insufficient balance.");
        }
    }

    public void ShowBalance()
    {
        Console.WriteLine("Current Balance: " + balance);
    }
}

class Program
{
    static void Main()
    {
        // Object creation
        BankAccount account = new BankAccount(1000);
        int choice;

        // Loop
        while (true)
        {

            // Display contents
            Console.WriteLine("\n1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine()); // Reading input and type casting

            // Switch case
            switch (choice)
            {
                case 1:
                    Console.Write("Enter amount: ");
                    double depositAmt = double.Parse(Console.ReadLine());
                    account.Deposit(depositAmt);
                    break;

                case 2:
                    Console.Write("Enter amount: ");
                    double withdrawAmt = double.Parse(Console.ReadLine());
                    account.Withdraw(withdrawAmt);
                    break;

                case 3:
                    account.ShowBalance();
                    break;

                case 4:
                    return; // Exits the program

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
