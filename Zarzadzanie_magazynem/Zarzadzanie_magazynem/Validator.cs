using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Validator : IValidator
{
    public void ValidateUserInput(string input, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException($"{fieldName} cannot be empty.");
        }
    }

    public void ValidateDateInput(string input)
    {
        if (!DateTime.TryParse(input, out _))
        {
            throw new ArgumentException("Invalid date format. Use yyyy-MM-dd.");
        }
    }
}