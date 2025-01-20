using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StatisticsManager
{
    public void GenerateUserStatistics(Warehouse warehouse)
    {
        Console.WriteLine("User Statistics:");
        foreach (var user in warehouse.Users)
        {
            Console.WriteLine(user);
        }
    }

    public void GenerateOverdueProducts(Warehouse warehouse)
    {
        Console.WriteLine("Overdue Products:");
        foreach (var user in warehouse.Users)
        {
            foreach (var product in user.Products)
            {
                if (product.ExpiryDate < DateTime.Now)
                {
                    Console.WriteLine($"User: {user.Name}, Product: {product.Name}, Expired on: {product.ExpiryDate.ToShortDateString()}");
                }
            }
        }
    }
}