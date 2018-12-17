
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotStoreDataLayer;
using RobotStoreDataLayer.Models;
using RobotsWebStore.Controllers;
using System.Collections.Generic;

namespace RobotStoreTests
{
    [TestClass]
    public class RobotTests
    {
        private DatabaseContext context;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
               .UseInMemoryDatabase(databaseName: "RobotsDatabase")
               .Options;

             context = new DatabaseContext(options);

            context.Robots.Add(new Robot
            {
                Id = 1,
                Name = "Robot1",
                Price = "10.00€"
            });
            context.Robots.Add(new Robot
            {
                Id = 2,
                Name = "Robot2",
                Price = "10.00€"
            });
            context.Robots.Add(new Robot
            {
                Id = 3,
                Name = "Robot3",
                Price = "10.00€"
            });
            context.Robots.Add(new Robot
            {
                Id = 4,
                Name = "Robot4",
                Price = "10.00€"
            });
            context.SaveChanges();

        }

        [TestMethod]
        public void GetAllRobots()
        {
                var controller = new RobotController(context);
                var robots =  controller.List().Result.Value;
                var robotsList = new List<Robot>(robots);
                Assert.AreEqual(robotsList.Count, 4);
        }

        [TestMethod]
        public void AddRobot()
        {
            var controller = new RobotController(context);
            Robot robot = new Robot { Id = 5, Name = "TestRobot", Price = "20.00€" };
            var addedRobot = controller.Add(robot).Result.Value;
            
            var robots = controller.List().Result.Value;
            var robotsList = new List<Robot>(robots);
            Assert.AreEqual(robotsList.Count, 5);
        }

        [TestMethod]
        public void DeleteRobot()
        {
            var controller = new RobotController(context);
            var deletedRobot = controller.Delete(1).Result.Value;

            var robots = controller.List().Result.Value;
            var robotsList = new List<Robot>(robots);
            Assert.AreEqual(robotsList.Count, 3);
        }

        [TestMethod]
        public void GetRobotById()
        {
            var controller = new RobotController(context);
            var robot = controller.Get(1).Result.Value;

            Assert.AreEqual(robot.Id, 1);
            Assert.AreEqual(robot.Name, "Robot1");
            Assert.AreEqual(robot.Price, "10.00€");
        }
    }
}
