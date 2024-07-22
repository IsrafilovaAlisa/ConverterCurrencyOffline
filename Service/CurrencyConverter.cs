using Azure;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using utf.Models;

namespace utf.Service
{
    public class CurrencyConverter : ObservableObject
    {
        //ключ к апи 
        private const string APIKey = "fca_live_LAfEb6eP0tqbK1r5ML0P4PVKOTRiOqqDIKCQDP6k";
        //ссылка на апи
        private const string URLApi = "https://api.freecurrencyapi.com/v1/latest?apikey=" + APIKey;
        //словарь валют
        private Dictionary<string, double> otherCurrency;

        //коллекция валют для интерфейса (ключи, значения)
        public ObservableCollection<string> KeysOtherCurrency { get; }

        public  CurrencyConverter()
        {
            //получаем курсы валют 
            //var cl = new HttpClient();
            //var response = cl.GetFromJsonAsync<CurrencyModel>(URLApi).Result;
            //var EUR = response.Data.EUR;
            //var USD = response.Data.USD;
            //var CAD = response.Data.CAD;

            ////заполняем словарь курсов валют 
            //otherCurrency = new Dictionary<string, double>()
            //{
            //    {"USD", USD },
            //    {"CAD", CAD },
            //    {"EUR", EUR},
            //};
            //KeysOtherCurrency = new ObservableCollection<string>(otherCurrency.Keys);

            var cl = new HttpClient();
            var response = cl.GetFromJsonAsync<CurrencyModel>(URLApi).Result; 
            FillCurrencyDictionary(response.Data);
            KeysOtherCurrency = new ObservableCollection<string>(otherCurrency.Keys);

        }
        /// <summary>
        /// заполнение словарика с курсами валют
        /// </summary>
        /// <param name="data">валюта</param>
        public void FillCurrencyDictionary(Data data)
        {
            otherCurrency = new Dictionary<string, double>();
            if(data != null)
            {
                foreach (var property in data.GetType().GetProperties())
                {
                    if (property.PropertyType == typeof(double))
                    {
                        string key = property.Name;
                        double value = (double)property.GetValue(data);
                        otherCurrency.Add(key, value);
                    }
                }
            }
        }

        /// <summary>
        /// конвертация валюты (из рублей)
        /// </summary>
        /// <param name="value">рубли</param>
        /// <param name="currency">целевая валюта</param>
        /// <returns></returns>
        public double Convert(double value, string currency)
        {
            return value * otherCurrency[currency];
        }
        /// <summary>
        /// Конвертация валюты (из валюты в валюту)
        /// </summary>
        /// <param name="value">Ввод пользователя</param>
        /// <param name="currencyFrom">ОТКУДА валюта</param>
        /// <param name="CurrencyTo">В КАКУЮ валюту</param>
        /// <returns></returns>
        public double Convert2(double value, string currencyFrom, string CurrencyTo)
        {
            return value / otherCurrency[currencyFrom] * otherCurrency[CurrencyTo];
        }
        


    }
}
