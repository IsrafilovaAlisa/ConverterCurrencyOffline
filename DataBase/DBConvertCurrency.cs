using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using utf.Models;
namespace utf.DataBase
{
    public  class DBConvertCurrency
    {
        public DbSet<ConvertCurrencyModel> ConvertCurrency { get; set; }
        public DBConvertCurrency()
        {
            
        }

        
    }
}
