using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IFileManager
{
    void SaveData(string filePath, List<User> users);
    List<User> LoadData(string filePath);
}
