using Microsoft.EntityFrameworkCore;


namespace utf.DataBase
{
    public class MyDbContext : DbContext
    {
        public DbSet<Purchases> Purchases { get; set; }

        public MyDbContext()
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "InformationABPurchases1")}");
        }
    }
}
