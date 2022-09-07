using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Abstract
{
    public  interface IUserRepository
    {
        List<User> GetAllUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);
        User GetUserById(int id);
    }
}
