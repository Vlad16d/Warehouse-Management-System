using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileManager : IFileManager
{
    public void SaveData(string filePath, List<User> users)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var user in users)
            {
                writer.WriteLine($"{user.Id};{user.Name}");
                foreach (var product in user.Products)
                {
                    writer.WriteLine($"{product.Id};{product.Name};{product.Quantity};{product.ExpiryDate:yyyy-MM-dd}");
                }
            }
        }
    }

    public List<User> LoadData(string filePath)
    {
        var users = new List<User>();

        if (!File.Exists(filePath)) return users;

        using (var reader = new StreamReader(filePath))
        {
            User currentUser = null;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split(';');
                if (data.Length == 2)
                {
                    currentUser = new User(int.Parse(data[0]), data[1]);
                    users.Add(currentUser);
                }
                else if (data.Length == 4 && currentUser != null)
                {
                    var product = new Product(int.Parse(data[0]), data[1], int.Parse(data[2]), DateTime.Parse(data[3]));
                    currentUser.Products.Add(product);
                }
            }
        }

        return users;
    }
}