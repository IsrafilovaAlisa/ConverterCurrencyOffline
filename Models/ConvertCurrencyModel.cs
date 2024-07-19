using SQLite;

namespace utf.Models
{
    /// <summary> модель для сохранения в базу журнала конвертированных валют </summary>
    public class ConvertCurrencyModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double? RUB { get; set; }
        public double? OtherCurrency { get; set; }
        public override string ToString()
        {
            return "Введенная сумма - " + (RUB.HasValue ? RUB.Value.ToString() : "Нет") +
                "; " + "Конвертация - " + (OtherCurrency.HasValue ? OtherCurrency.Value.ToString() : "Нет");
        }
    }
}
