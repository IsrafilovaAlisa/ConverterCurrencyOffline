using SQLite;
using System.Diagnostics;
using utf.Service;

namespace utf.Models
{
    /// <summary> модель для сохранения в базу журнала конвертированных валют </summary>
    public class ConvertCurrencyModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double? RUB { get; set; }
        public double? OtherCurrency { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }

        public override string ToString()
        {
            return $"Введенная сумма ({CurrencyFrom}) - " + (RUB.HasValue ? RUB.Value.ToString() : "Нет") +
                "; " + $"Конвертация ({CurrencyTo}) - " + (OtherCurrency.HasValue ? OtherCurrency.Value.ToString("F2") : "Нет");
            
        }
        
        
    }
}
