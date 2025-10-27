using System;
using System.Collections.Generic; // For List<T>
using System.Linq; // For .FirstOrDefault()

public class Bank
{
    // The bank holds a list of all accounts
    private List<Account> accounts;

    public Bank()
    {
        // Initialize the list in the constructor
        accounts = new List<Account>();
    }

    public void OpenAccount(Account account)
    {
        accounts.Add(account);
        Console.WriteLine($"Account opened for {account.OwnerName}. Account Number: {account.AccountNumber}");
    }

    // We can search the list to find an account
    public Account GetAccount(string accountNumber)
    {
        // Use Linq to find the first account that matches, or return null
        return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
    }
}