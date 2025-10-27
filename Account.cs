using System;

public class Account
{
    // Properties
    public string AccountNumber { get; private set; }
    public string OwnerName { get; set; }
    public decimal Balance { get; protected set; } // 'protected set' lets child classes change it

    // Constructor
    public Account(string ownerName, decimal initialBalance)
    {
        this.OwnerName = ownerName;
        this.Balance = initialBalance;

        // Generate a random 10-digit account number
        Random rand = new Random();
        this.AccountNumber = rand.Next(1000000000, 2000000000).ToString();
    }

    // Methods
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
            return;
        }
        this.Balance += amount;
        Console.WriteLine($"Deposited ${amount}. New balance: ${this.Balance}");
    }

    // This method is 'virtual', meaning child classes can 'override' it
    public virtual bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return false;
        }

        if (this.Balance - amount < 0)
        {
            Console.WriteLine("Insufficient funds.");
            return false;
        }

        this.Balance -= amount;
        Console.WriteLine($"Withdrew ${amount}. New balance: ${this.Balance}");
        return true;
    }
}