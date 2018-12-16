using Microsoft.EntityFrameworkCore;
using RobotStoreDataLayer.Common;
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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => new { u.Id, u.Username });

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "creator" },
                new Role { Id = 2, Name = "reader" });
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = PasswordManager.ComputeSha256Hash("admin"), RoleId = 1 },
                new User { Id = 2, Username = "reader", Password = PasswordManager.ComputeSha256Hash("reader"), RoleId = 2 });


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

        }
    }
}
