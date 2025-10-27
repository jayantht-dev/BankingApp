using System;

// 'CheckingAccount' also inherits from 'Account'
public class CheckingAccount : Account
{
    public decimal OverdraftFee { get; set; }

    public CheckingAccount(string ownerName, decimal initialBalance, decimal overdraftFee)
        : base(ownerName, initialBalance)
    {
        this.OverdraftFee = overdraftFee;
    }

    // 'override' changes the 'virtual' Withdraw method from the parent
    public override bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return false;
        }

        // The new rule: allow overdraft (go negative)
        if (this.Balance - amount < -100) // Let's say a $100 overdraft limit
        {
            Console.WriteLine("Withdrawal exceeds overdraft limit.");
            return false;
        }

        this.Balance -= amount;
        Console.WriteLine($"Withdrew ${amount}. New balance: ${this.Balance}");

        // The new rule: apply a fee if overdrawn
        if (this.Balance < 0)
        {
            this.Balance -= OverdraftFee;
            Console.WriteLine($"Overdraft fee of ${OverdraftFee} applied. New balance: ${this.Balance}");
        }
        return true;
    }
}