using System;
using System.Collections.Generic;
using System.IO;

namespace Zarzadzanie_magazynem
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=NITRO\\SQLEXPRESS02;Database=WarehouseDB;Trusted_Connection=True;";
            var databaseManager = new DatabaseManager(connectionString);
            var warehouse = new Warehouse(databaseManager);

            Console.WriteLine("Warehouse Management System");
            Console.WriteLine("1. Add User\n2. Add Product\n3. Show All Users\n4. Show Products of User\n5. Exit");

            bool running = true;
            while (running)
            {
                Console.Write("Choose an option: ");
                var option = Console.ReadLine();

                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.Write("Enter User Name: ");
                            string userName = Console.ReadLine();
                            warehouse.AddUser(userName);
                            Console.WriteLine("User added successfully.");
                            break;

                        case "2":
                            Console.Write("Enter User ID: ");
                            if (!int.TryParse(Console.ReadLine(), out int userId))
                            {
                                Console.WriteLine("Invalid User ID.");
                                break;
                            }

                            Console.Write("Enter Product Name: ");
                            string productName = Console.ReadLine();
                            Console.Write("Enter Quantity: ");
                            if (!int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                Console.WriteLine("Invalid Quantity.");
                                break;
                            }

                            Console.Write("Enter Expiry Date (yyyy-MM-dd): ");
                            if (!DateTime.TryParse(Console.ReadLine(), out DateTime expiryDate))
                            {
                                Console.WriteLine("Invalid Date Format.");
                                break;
                            }

                            warehouse.AddProductToUser(userId, productName, quantity, expiryDate);
                            Console.WriteLine("Product added successfully.");
                            break;

                        case "3":
                            var users = warehouse.GetAllUsers();
                            foreach (var user in users)
                            {
                                Console.WriteLine(user);
                            }
                            break;

                        case "4":
                            Console.Write("Enter User ID: ");
                            if (!int.TryParse(Console.ReadLine(), out userId))
                            {
                                Console.WriteLine("Invalid User ID.");
                                break;
                            }

                            var products = warehouse.GetProductsOfUser(userId);
                            foreach (var product in products)
                            {
                                Console.WriteLine(product);
                            }
                            break;

                        case "5":
                            running = false;
                            Console.WriteLine("Exiting program.");
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}