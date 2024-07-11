﻿using SQLite;

namespace utf.DataBase
{
    public class Purchases
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? Purchase { get; set; }
        public int? PriceRUB { get; set; }
        //public string PriceConverted { get; set; }
        //public DateTime Date { get; set; }
        public override string ToString()
        {
            return "(ID - " + ID+ ") Покупка - " + (Purchase ?? "Нет") + "; " + "Цена - " + (PriceRUB.HasValue ? PriceRUB.Value.ToString() : "Нет") + ";";
        }
    }
}
