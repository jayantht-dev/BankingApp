using System;

class Program
{
    // Make 'bank' static so all methods in Program can use it
    static Bank myBank = new Bank();

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Simple Bank Menu ---");
            Console.WriteLine("1. Open a new Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. View Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    OpenAccount();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    Withdraw();
                    break;
                case "4":
                    ViewBalance();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void OpenAccount()
    {
        Console.WriteLine("\n--- Open New Account ---");
        Console.Write("Enter owner name: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter initial deposit: ");
        decimal initial = decimal.Parse(Console.ReadLine()!); // Use decimal.Parse

        Console.Write("Account type (1: Checking, 2: Savings): ");
        string type = Console.ReadLine()!;

        if (type == "1")
        {
            CheckingAccount checking = new CheckingAccount(name, initial, 35.00m); // 35 dollar fee
            myBank.OpenAccount(checking);
        }
        else if (type == "2")
        {
            SavingsAccount savings = new SavingsAccount(name, initial, 0.02m); // 2% interest
            myBank.OpenAccount(savings);
        }
        else
        {
            Console.WriteLine("Invalid account type.");
        }
    }

    static Account? FindAccount()
    {
        Console.Write("Enter account number: ");
        string accNum = Console.ReadLine()!;
        Account? account = myBank.GetAccount(accNum);

        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return null;
        }
        return account;
    }

    static void Deposit()
    {
        Console.WriteLine("\n--- Deposit ---");
        Account? account = FindAccount();
        if (account != null)
        {
            Console.Write("Enter deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine()!);
            account.Deposit(amount);
        }
    }

    static void Withdraw()
    {
        Console.WriteLine("\n--- Withdraw ---");
        Account? account = FindAccount();
        if (account != null)
        {
            Console.Write("Enter withdrawal amount: ");
            decimal amount = decimal.Parse(Console.ReadLine()!);
            account.Withdraw(amount); // This will call the correct (overridden) method!
        }
    }

    static void ViewBalance()
    {
        Console.WriteLine("\n--- View Balance ---");
        Account? account = FindAccount();
        if (account != null)
        {
            Console.WriteLine($"Account {account.AccountNumber} ({account.OwnerName}): ${account.Balance}");
        }
    }
}