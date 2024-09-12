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
        
    }
}
