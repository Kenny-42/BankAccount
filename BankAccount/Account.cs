using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;
public class Account
{
    /// <summary>
    /// AccountNumbers must start with 4 digits followed by
    /// a dash and then 5 characters (A-Z) not case sensitive
    /// </summary>
    public string AccountNumber { get; set; }

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
            throw new ArgumentOutOfRangeException(nameof(amount), "Cannot withdraw negative or more than current balance.")
        }

        Balance -= amount;
        return Balance;
    }
}
