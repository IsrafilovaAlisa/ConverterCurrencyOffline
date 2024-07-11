using Azure;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using utf.Models;

namespace utf.APIService
{
    public class APIConnect
    {
        private const string APIKey = "fca_live_LAfEb6eP0tqbK1r5ML0P4PVKOTRiOqqDIKCQDP6k";
        private const string URLApi = "https://api.freecurrencyapi.com/v1/latest?apikey=" + APIKey + "&currencies=EUR,USD,CAD&base_currency=RUB";
        private Dictionary<string, double> convertedCurrency;


        public ObservableCollection<string> ConvertedCurrency { get; set; } = new();

        public APIConnect()
        {
            var cl = new HttpClient();
            var response = cl.GetFromJsonAsync<CurrencyModel>(URLApi).Result;
            var EUR = response.Data.Eur;
            var USD = response.Data.Usd;
            var CAD = response.Data.Cad;

            convertedCurrency = new Dictionary<string, double>()
            {
                {"USD" , USD },
                {"CAD", CAD },
                {"EUR", EUR},

            };
            ConvertedCurrency = new ObservableCollection<string>(convertedCurrency.Keys);
        }
    }
}
