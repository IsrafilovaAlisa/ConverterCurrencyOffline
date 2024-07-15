using Microsoft.EntityFrameworkCore;
using utf.Models;


namespace utf.DataBase
{
    public class MyDbContext : DbContext
    {
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<ConvertCurrencyModel> ConvertCurrency { get; set; }
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
