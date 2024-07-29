using Microsoft.EntityFrameworkCore;
using utf.Models;


namespace utf.ManagementDB
{
    public class MyDbContext : DbContext
    {
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<ConvertCurrencyModel> ConvertCurrency { get; set; }
        public MyDbContext()
        {
            //При добавлении новых функций/свойств/др. фич раскоментировать строку ниже для удаления существующей бд 
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "InformationABPurchases1")}");
        }
    }
}
