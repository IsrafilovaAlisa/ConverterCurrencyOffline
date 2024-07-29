using SQLite;

namespace utf.Models
{
    public class PurchasesModel
    {
        /// <summary> модель для страницы с журналом покупок </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? Purchase { get; set; }
        public int? PriceRUB { get; set; }
        public double? PriceConverted { get; set; }
        public DateTime? DatePurchase { get; set; }
        //public DateTime Date { get; set; }
        public override string ToString()
        {
            return "(ID - " + ID + ") Покупка - " + (Purchase ?? "Нет") +
                "; " + "Цена - " + (PriceRUB.HasValue ? PriceRUB.Value.ToString() : "Нет") +
                "; " + "Конвертация - " + (PriceConverted.HasValue ? PriceConverted.Value.ToString() : "Конвертация не произведена" +
                "; " + (DatePurchase.HasValue ? "Дата - " + DatePurchase.Value.ToString("d") : "Дата - Нет"));
        }
    }
}
