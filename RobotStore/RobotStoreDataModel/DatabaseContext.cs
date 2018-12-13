using Microsoft.EntityFrameworkCore;
using RobotStoreDataLayer.Models;

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

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Robot>().HasData(
    //    new Robot
    //    {
    //        Name = "Robot1",
    //        Price = "10.00€"
    //    },
    //    new Robot
    //    {
    //        Name = "Robot2",
    //        Price = "10.00€"
    //    },
    //    new Robot
    //    {
    //        Name = "Robot3",
    //        Price = "10.00€"
    //    },
    //    new Robot
    //    {
    //        Name = "Robot4",
    //        Price = "10.00€"
    //    }
    //);
    //    }
    }
}
