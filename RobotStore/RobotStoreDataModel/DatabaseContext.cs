using Microsoft.EntityFrameworkCore;
using RobotStoreDataLayer.Models;
using System.Collections.Generic;

namespace RobotStoreDataLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {

        }

        public DbSet<Robot> Robots { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=:memory:");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robot>().HasData(
                new Robot
        {
            Id = 1,
            Name = "Robot1",
            Price = "10.00€"
        },
                new Robot
        {
            Id = 2,
            Name = "Robot2",
            Price = "10.00€"
        },
                new Robot
        {
            Id = 3,
            Name = "Robot3",
            Price = "10.00€"
        },
                new Robot
        {
            Id = 4,
            Name = "Robot4",
            Price = "10.00€"
        }
            );

            //var userRoleMapping = new UserRoleMapping { Id = 1, UserFK = 1 };

            //modelBuilder.Entity<UserRoleMapping>().HasData(userRoleMapping);

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = 1,
            //        Username = "admin",
            //        Password = "admin",
            //        UserRoleMappings = new List<UserRoleMapping> { userRoleMapping }
            //    });

            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "creator" });

            modelBuilder.Entity<User>().HasData(new User { RoleId = 1, Id = 1, Username = "admin", Password = "admin" });

        }
    }
}
