using System.Data.Entity;

namespace RecsApp
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppContext") { }

        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<EstCategory> Categories { get; set; }
        public DbSet<EstType> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EstFood> Foods { get; set; }
        public DbSet<EstAverageCheck> AverageChecks { get; set; }
    }
}
