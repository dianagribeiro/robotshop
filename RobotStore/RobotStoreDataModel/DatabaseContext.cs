using Microsoft.EntityFrameworkCore;

namespace RobotStoreDataLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        { }

        public DbSet<Robot> Robots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=:memory:");
            }
        }
    }
}
