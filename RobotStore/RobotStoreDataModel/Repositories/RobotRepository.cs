using RobotStoreDataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace RobotStoreDataLayer.Repositories
{
    public class RobotRepository
    {
        private DatabaseContext _context;

        public RobotRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Robot robot)
        {
            _context.Robots.Add(robot);
        }

        public Robot Find(int id)
        {
            return _context.Robots.Where(X => X.Id == id).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var robotToRemove = _context.Robots.Where(X => X.Id == id).FirstOrDefault();
            _context.Robots.Remove(robotToRemove);
        }

        public List<Robot> GetRobots()
        {
            return _context.Robots.ToList();
        }
    }
}
