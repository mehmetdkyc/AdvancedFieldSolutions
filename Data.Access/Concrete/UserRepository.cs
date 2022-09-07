using Data.Access.Abstract;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(User user)
        {
            using (var context = new AdvancedDbContext())
            {
                context.User.Add(user);
                context.SaveChanges();
                return user;
            }
        }

        public void DeleteUser(User user)
        {
            using (var context = new AdvancedDbContext())
            {
                context.User.Remove(user);
            }
        }

        public List<User> GetAllUsers()
        {
            using (var context = new AdvancedDbContext())
            {
                return context.User.ToList();

            }
        }

        public User GetUserById(int id)
        {
            using (var context = new AdvancedDbContext())
            {
                var userFind = context.User.FirstOrDefault(x => x.Id == id);
                return userFind;
            }
        }

        public User UpdateUser(User user)
        {
            using (var context = new AdvancedDbContext())
            {
                context.User.Update(user);
                return user;
            }
        }
    }
}
