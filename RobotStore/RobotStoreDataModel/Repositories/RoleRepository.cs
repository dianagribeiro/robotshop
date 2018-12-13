using RobotStoreDataLayer;
using RobotStoreDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace roleStoreDataLayer.Repositories
{
    public class RoleRepository
    {
        private DatabaseContext _context;

        public RoleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Role role)
        {
            _context.Roles.Add(role);
        }

        public Role Find(int id)
        {
            return _context.Roles.Where(X => X.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var roleToRemove = _context.Roles.Where(X => X.Id == id).FirstOrDefault();
            _context.Roles.Remove(roleToRemove);
        }

        public List<Role> Getroles()
        {
            return _context.Roles.ToList();
        }
    }
}
