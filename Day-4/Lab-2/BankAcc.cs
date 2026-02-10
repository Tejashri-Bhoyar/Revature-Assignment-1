using System;

public class BankAccount
{
    // Private fields
    private string _accountNumber;
    private decimal _balance;

    // Property with validation
    public string AccountNumber
    {
        get { return _accountNumber; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Account number cannot be empty");

            _accountNumber = value;
        }
    }

    // Property with validation
    public decimal Balance
    {
        get { return _balance; }
        private set
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be negative");

            _balance = value;
        }
    }

    // Constructor
    public BankAccount(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    // Method to deposit money
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero");

        Balance += amount;
    }

    // Method to withdraw money
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdraw amount must be greater than zero");

        if (amount > Balance)
            throw new InvalidOperationException("Insufficient balance");

        Balance -= amount;
    }
}