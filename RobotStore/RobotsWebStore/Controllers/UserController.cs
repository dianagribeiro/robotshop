using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobotStoreDataLayer;
using RobotStoreDataLayer.Models;

namespace RobotsWebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                // Create new Robot if collection is empty,
                // which means you can't delete all Robot.
                var user = new User { Username = "username", Password = "password" };
                var role = new Role { Name = "ReadAndCreate" };
                _context.Roles.Add(role);
                _context.SaveChanges();
                _context.Users.Add(user);
                user.Roles.Add(role);
                _context.SaveChanges();
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<User>>> List()
        {
            return await _context.Users.ToListAsync();
        }
    }
}