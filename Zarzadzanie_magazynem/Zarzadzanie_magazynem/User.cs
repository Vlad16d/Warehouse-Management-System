using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public override string ToString()
    {
        return $"User ID: {Id}, Name: {Name}, Products Count: {Products.Count}";
    }
}
