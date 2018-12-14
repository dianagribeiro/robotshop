using RobotStoreDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotStoreDataLayer.Repositories
{
    public class UserRepository
    {
        private DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public User Find(int id)
        {
            return _context.Users.Where(X => X.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var userToRemove = _context.Users.Where(X => X.Id == id).FirstOrDefault();
            _context.Users.Remove(userToRemove);
        }

        public List<User> Getroles()
        {
            return _context.Users.ToList();
        }
    }
}
