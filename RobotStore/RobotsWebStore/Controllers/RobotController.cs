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
    public class RobotController : Controller
    {
        private readonly DatabaseContext _context;

        public RobotController(DatabaseContext context)
        {
            _context = context;

            if (_context.Robots.Count() == 0)
            {
                // Create new Robot if collection is empty,
                // which means you can't delete all Robot.
                _context.Robots.Add(new Robot { Name = "Robot1", Price = "1.00€" });
                _context.Robots.Add(new Robot { Name = "Robot2", Price = "5.00€" });
                _context.Robots.Add(new Robot { Name = "Robot3", Price = "10.00€" });
                _context.Robots.Add(new Robot { Name = "Robot4", Price = "20.00€" });
                _context.Robots.Add(new Robot { Name = "Robot5", Price = "8.00€" });
                _context.SaveChanges();
            }
        }

        //GET: api/robot/list
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Robot>>> List()
        {
            return await _context.Robots.ToListAsync();
        }

        //GET: api/robot/get/1 
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Robot>> Get(long id) 
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
        public async Task<ActionResult<Robot>> Add(Robot robot)
        {
            _context.Robots.Add(robot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddRobot", new { id = robot.Id }, robot);
        }

        // DELETE: api/robot/delete/1
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Robot>> Delete(long id)
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