using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;
public class Validator
{
    /// <summary>
    /// Checks to ensure a value is between inclusive boundaries
    /// </summary>
    /// <param name="value">Value to check</param>
    /// <param name="min">Minimum inclusive boundary</param>
    /// <param name="max">Maximum inclusive boundary</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown if min boundary is greater than max boundary</exception>
    public bool IsWithinRange(double value, double min, double max)
    {
        if (min > max)
        {
            throw new ArgumentException("Min cannot be greater than the max.");
        }
        if (value >= min && value <= max)
        {
            return true;
        }
        return false;
    }
}
