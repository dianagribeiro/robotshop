
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
        private DbContextOptions<DatabaseContext> options;
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
    }
}
