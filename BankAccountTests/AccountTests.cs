using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccount.Tests;

[TestClass]
public class AccountTests
{
    [TestMethod]
    public void Deposit_ValidAmount_IncreasesBalance()
    {
        // Arrange
        var account = new Account { AccountNumber = "1234-ABCDE" };

        // Act
        var result = account.Deposit(100m);

        // Assert
        Assert.AreEqual(100m, result); // Method returns updated balance value
        Assert.AreEqual(100m, account.Balance); // Actual balance is updated
    }

    [TestMethod]
    public void Deposit_NonPositiveAmount_ThrowsException()
    {
        var account = new Account { AccountNumber = "1234-ABCDE" };
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposit(0));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposit(-50));
    }

    [TestMethod]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        var account = new Account { AccountNumber = "1234-ABCDE" };
        account.Deposit(200m); // Ensure balance is sufficient
        var result = account.Withdraw(50m);
        Assert.AreEqual(150m, result); // Method returns updated balance value
        Assert.AreEqual(150m, account.Balance); // Actual balance is updated
    }

    [TestMethod]
    public void Withdraw_NonPositiveAmount_ThrowsException()
    {
        var account = new Account { AccountNumber = "1234-ABCDE" };
        account.Deposit(100m); // Ensure balance is sufficient
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(0));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(-50));
    }

    [TestMethod]
    public void Withdraw_MoreThanBalance_ThrowsException()
    {
        var account = new Account { AccountNumber = "1234-ABCDE" };
        account.Deposit(100m);
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(150m));
    }

    [TestMethod]
    public void AccountNumber_SetAndGet_WorksCorrectly()
    {
        var account = new Account { AccountNumber = "4321-ZYXWV" };
        Assert.AreEqual("4321-ZYXWV", account.AccountNumber);
    }

    [TestMethod]
    [DataRow("1234-ABCDE")]
    [DataRow("0000-ZYXWV")]
    [DataRow("9999-AAAAA")]
    [DataRow("5555-qwert")]
    public void AccountNumber_ValidFormat_DoesNotThrow(string validAccountNumber)
    {
        // Act & Assert
        var account = new Account { AccountNumber = validAccountNumber };
        Assert.AreEqual(validAccountNumber, account.AccountNumber);
    }

    [TestMethod]
    [DataRow("")]
    [DataRow(null)]
    [DataRow("123-ABCDE")]
    [DataRow("12345-ABCDE")]
    [DataRow("1234-ABCDEF")]
    [DataRow("1234-abc1e")]
    [DataRow("12A4-ABCDE")]
    [DataRow("1234-12345")]
    [DataRow("abcd-ABCDE")]
    public void AccountNumber_InvalidFormat_ThrowsArgumentException(string invalidAccountNumber)
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => new Account { AccountNumber = invalidAccountNumber });
    }
}
