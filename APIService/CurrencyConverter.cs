using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using utf.Models;

namespace utf.APIService
{
    public class CurrencyConverter : ObservableObject
    {
        //ключ к апи 
        private const string APIKey = "fca_live_LAfEb6eP0tqbK1r5ML0P4PVKOTRiOqqDIKCQDP6k";
        //ссылка на апи
        private const string URLApi = "https://api.freecurrencyapi.com/v1/latest?apikey=" + APIKey + "&currencies=EUR,USD,CAD&base_currency=RUB";
        //словарь валют
        private Dictionary<string, double> otherCurrency;

        //коллекция валют для интерфейса (ключи, значения)
        public ObservableCollection<string> KeysOtherCurrency { get; }

        public  CurrencyConverter()
        {
            //получаем курсы валют 
            var cl = new HttpClient();
            var response = cl.GetFromJsonAsync<CurrencyModel>(URLApi).Result;
            var EUR = response.Data.Eur;
            var USD = response.Data.Usd;
            var CAD = response.Data.Cad;

            //заполняем словарь курсов валют 
            otherCurrency = new Dictionary<string, double>()
            {
                {"USD", USD },
                {"CAD", CAD },
                {"EUR", EUR},
            };
            KeysOtherCurrency = new ObservableCollection<string>(otherCurrency.Keys);
            
        }

        /// <summary>
        /// конвертация валюты 
        /// </summary>
        /// <param name="value">рубли</param>
        /// <param name="currency">целевая валюта</param>
        /// <returns></returns>
        public double Convert(double value, string currency)
        {
            return value * otherCurrency[currency];
        }
        
        
    }
}
