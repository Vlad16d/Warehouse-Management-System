using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IUserManager
{
    void AddUser(User user);
    void AddProductToUser(int userId, Product product);
    List<User> GetAllUsers();
    User GetUserById(int userId);
}