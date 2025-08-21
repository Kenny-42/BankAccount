using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests;
[TestClass()]
public class ValidatorTests
{
    [TestMethod()]
    [DataRow(10, 10)]
    [DataRow(5.001, 5.001)]
    [DataRow(1.000005, 1.000005)]
    [DataRow(-50.01, -50.01)]
    public void IsWithinRange_MinInclusiveBound_ReturnsTrue(double minBoundary, double valueToCheck)
    {
        // Arrange - arranging all the data we need for the test
        Validator validator = new();
        double maxBoundary = 100;

        // Act - call method we are testing
        bool result = validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary);

        // Assert
        Assert.IsTrue(result);
    }
    
    [TestMethod()]
    public void IsWithinRange_MaxInclusiveBound_ReturnsTrue()
    {
        // Arrange
        Validator validator = new();
        double minBoundary = 1;
        double maxBoundary = 10;
        double valueToCheck = 10;
        // Act
        bool result = validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    [DataRow(1, 100, 50)]
    [DataRow(1, 100, 1.000001)]
    [DataRow(1, 100, 99.9999999)]
    [DataRow(-100, 10, -40)]
    public void IsWithinRange_ValueWithinRange_ReturnsTrue(double minBoundary, double maxBoundary, double valueToCheck)
    {
        // Arrange
        Validator validator = new();

        // Act
        bool result = validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void IsWithinRange_ValueLessThanMinBoundary_ReturnFalse()
    {
        Validator validator = new();
        double minBoundary = 6;
        double maxBoundary = 100;
        double valueToCheck = 5;

        bool result = new Validator().IsWithinRange(valueToCheck, minBoundary, maxBoundary);

        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void IsWithinRange_ValueGreaterThanMaxBoundary_ReturnFalse()
    {
        Validator validator = new();
        double minBoundary = 0;
        double maxBoundary = 1000;
        double valueToCheck = 1000.01;

        bool result = new Validator().IsWithinRange(valueToCheck, minBoundary, maxBoundary);
        
        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void IsWithinRange_MinGreaterThanMax_ThrowsArgumentException()
    {
        Validator validator = new();
        double minBoundary = 100;
        double maxBoundary = 0;
        double valueToCheck = 50;

        Assert.ThrowsException<ArgumentException>(() => validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary));
    }
}