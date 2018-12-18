using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobotStoreDataLayer;
using RobotStoreDataLayer.Models;
using RobotsWebStore.Filters;

namespace RobotsWebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : Controller
    {
        private readonly DatabaseContext _context;

        public RobotController(DatabaseContext context)
        {
            _context = context;
        }

        //GET: api/robot/list
        [HttpGet("[action]")]
        [JwtAuthorizationFilter("creator", "reader")]
        public async Task<ActionResult<IEnumerable<Robot>>> List()
        {
            return await _context.Robots.ToListAsync();
        }

        //GET: api/robot/get/1 
        [HttpGet("[action]/{id}")]
        [JwtAuthorizationFilter("creator", "reader")]
        public async Task<ActionResult<Robot>> Get(int id) 
        {
            var robot = await _context.Robots.FindAsync(id);

            if(robot == null)
            {
                return NotFound();
            }
            else
            {
                return robot;
            }
        }

        //POST: api/robot/add --- create json body with values
        [HttpPost("[action]")]
        [JwtAuthorizationFilter("creator")]
        public async Task<ActionResult<Robot>> Add(Robot robot)
        {
            var id = _context.Robots.LastOrDefault().Id + 1;
            robot.Id = id;
            _context.Robots.Add(robot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddRobot", new { id = robot.Id }, robot);
        }

        // DELETE: api/robot/delete/1
        [HttpDelete("[action]/{id}")]
        [JwtAuthorizationFilter("creator")]
        public async Task<ActionResult<Robot>> Delete(int id)
        {
            var robot = await _context.Robots.FindAsync(id);
            if (robot == null)
            {
                return NotFound();
            }

            _context.Robots.Remove(robot);
            await _context.SaveChangesAsync();

            return robot;
        }

    }
}