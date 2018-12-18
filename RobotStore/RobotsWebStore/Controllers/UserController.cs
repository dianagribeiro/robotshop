using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobotStoreDataLayer;
using RobotStoreDataLayer.Common;
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

        }

        //[HttpGet("[action]")]
        //public async Task<ActionResult<IEnumerable<User>>> List()
        //{
        //    return await _context.Users.Include(u => u.Role).ToListAsync();
        //}

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string username, string password)
        {
            var passwordHash = PasswordManager.ComputeSha256Hash(password);

            var user = await _context.Users.Include(u=> u.Role).SingleAsync(u => u.Username == username);

            if(user == null)
            {
                return NotFound();
            }
            else
            {
                if(user.Password == passwordHash)
                {
                    return Ok(new { data = TokenManager.GenerateToken(user), username = user.Username });
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}