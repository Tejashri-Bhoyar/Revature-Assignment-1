// See https://aka.ms/new-console-template for more information

// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        try
        {
            BankAccount account = new BankAccount("ACC123", 5000);

            Console.WriteLine($"Account: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance}");

            account.Deposit(1000);
            Console.WriteLine($"After deposit: {account.Balance}");

            account.Withdraw(2000);
            Console.WriteLine($"After withdrawal: {account.Balance}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}