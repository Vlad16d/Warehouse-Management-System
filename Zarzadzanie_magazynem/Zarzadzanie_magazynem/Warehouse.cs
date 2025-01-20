using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Warehouse
{
    private readonly DatabaseManager _databaseManager;

    public List<User> Users { get; private set; }

    public Warehouse(DatabaseManager databaseManager)
    {
        _databaseManager = databaseManager;
        Users = new List<User>();
    }

    public void LoadUsersFromDatabase()
    {
        string query = "SELECT * FROM Users;";
        var result = _databaseManager.ExecuteQuery(query);

        Users = result.Select(row => new User(
            id: (int)row["Id"],
            name: (string)row["Name"]
        )).ToList();

    }

    public void AddUser(string name)
    {
        string query = "INSERT INTO Users (Name) VALUES (@Name);";
        var parameters = new Dictionary<string, object> { { "@Name", name } };
        _databaseManager.ExecuteNonQuery(query, parameters);
    }

    public void AddProductToUser(int userId, string productName, int quantity, DateTime expiryDate)
    {
        string query = @"INSERT INTO Products (Name, Quantity, ExpiryDate, UserId) 
                             VALUES (@Name, @Quantity, @ExpiryDate, @UserId);";
        var parameters = new Dictionary<string, object>
            {
                { "@Name", productName },
                { "@Quantity", quantity },
                { "@ExpiryDate", expiryDate.ToString("yyyy-MM-dd") },
                { "@UserId", userId }
            };
        _databaseManager.ExecuteNonQuery(query, parameters);
    }

    public List<string> GetAllUsers()
    {
        string query = "SELECT * FROM Users;";
        var result = _databaseManager.ExecuteQuery(query);
        return result.Select(row => $"User ID: {row["Id"]}, Name: {row["Name"]}").ToList();
    }

    public List<string> GetProductsOfUser(int userId)
    {
        string query = "SELECT * FROM Products WHERE UserId = @UserId;";
        var parameters = new Dictionary<string, object> { { "@UserId", userId } };
        var result = _databaseManager.ExecuteQuery(query, parameters);

        return result.Select(row =>
            $"Product ID: {row["Id"]}, Name: {row["Name"]}, Quantity: {row["Quantity"]}, Expiry Date: {row["ExpiryDate"]}"
        ).ToList();
    }

}