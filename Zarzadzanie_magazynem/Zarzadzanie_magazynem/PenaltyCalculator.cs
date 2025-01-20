using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PenaltyCalculator
{
    private const decimal PenaltyPerDay = 5.0m;

    public decimal CalculatePenalty(Product product)
    {
        var overdueDays = (DateTime.Now - product.ExpiryDate).Days;
        return overdueDays > 0 ? overdueDays * PenaltyPerDay : 0;
    }
}