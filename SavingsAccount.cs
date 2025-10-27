using System;

// 'SavingsAccount' inherits from 'Account'
public class SavingsAccount : Account
{
    public decimal InterestRate { get; set; }

    // The constructor takes its parameters and passes some 'base' to the parent's constructor
    public SavingsAccount(string ownerName, decimal initialBalance, decimal interestRate)
        : base(ownerName, initialBalance)
    {
        this.InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = this.Balance * this.InterestRate;
        this.Balance += interest; // We can change 'Balance' because it's 'protected'
        Console.WriteLine($"Applied ${interest} interest. New balance: ${this.Balance}");
    }
}