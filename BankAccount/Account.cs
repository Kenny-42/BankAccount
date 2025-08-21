using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;
public class Account
{
    private string _accountNumber = string.Empty;

    /// <summary>
    /// AccountNumbers must start with 4 digits followed by
    /// a dash and then 5 characters (A-Z) not case sensitive
    /// </summary>
    public required string AccountNumber
    {
        get => _accountNumber;
        init
        {
            if (!IsValidAccountNumber(value))
                throw new ArgumentException("Invalid AccountNumber format.", nameof(AccountNumber));
            _accountNumber = value;
        }
    }

    private static bool IsValidAccountNumber(string accountNumber)
    {
        if (string.IsNullOrWhiteSpace(accountNumber)) return false;
        // Format: 4 digits, 5 letters (A-Z, case insensitive)
        return System.Text.RegularExpressions.Regex.IsMatch(accountNumber, @"^\d{4}-[A-Za-z]{5}$");
    }

    /// <summary>
    /// The current balance of the account
    /// </summary>
    public decimal Balance { get; private set; }

    /// <summary>
    /// Deposit money  into the account and returns the new balance
    /// </summary>
    /// <param name="amount">The amount to deposit. Must be a positive value.</param>
    /// <returns>The updated account balance after the deposit.</returns>
    public decimal Deposit(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Balance += amount;
        return Balance;
    }

    /// <summary>
    /// Withdraws the specified amount from the account balance.
    /// </summary>
    /// <param name="amount">The amount to withdraw. Must be a positive value.</param>
    /// <returns>The updated account balance after the withdrawal.</returns>
    public decimal Withdraw (decimal amount)
    {
        if (amount <= 0 || amount > Balance)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Cannot withdraw negative or more than current balance.");
        }

        Balance -= amount;
        return Balance;
    }
}
