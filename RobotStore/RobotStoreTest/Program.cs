using Microsoft.EntityFrameworkCore;
using RobotStoreDataLayer;
using System;
using System.Linq;

namespace RobotStoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlite("DataSource=:memory:")
                    .Options;

            // Run the test against one instance of the context
            using (var context = new DatabaseContext(options))
            {
                var users = context.Users.ToList();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Username);
                }
            }

            

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
