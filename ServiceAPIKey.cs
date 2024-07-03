using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace utf
{
    public class ServiceAPIKey
    {
        //private const string APIKey = "fca_live_LAfEb6eP0tqbK1r5ML0P4PVKOTRiOqqDIKCQDP6k";
        //private const string URLApi = "https://api.freecurrencyapi.com/v1/latest?apikey=fca_live_LAfEb6eP0tqbK1r5ML0P4PVKOTRiOqqDIKCQDP6k&currencies=EUR%2CUSD%2CCAD&base_currency=RUB";


        private const string APIKey = "fca_live_LAfEb6eP0tqbK1r5ML0P4PVKOTRiOqqDIKCQDP6k";
        private const string URLApi = "https://api.freecurrencyapi.com/v1/latest?apikey=" + APIKey + "&currencies=EUR,USD,CAD&base_currency=RUB";

        public async Task CurrencyServiceClient()
        {
            var cl = new HttpClient();
            var response = await cl.GetAsync(URLApi);
            var result = await response.Content.ReadAsStringAsync();
        }
        public ServiceAPIKey() 
        {

        }
        //public void CurrencyServiceClient()
        //{
        //    var cl = new HttpClient();
        //    var content = new StringContent(JsonConvert.SerializeObject(new { app_id = APIKey }), Encoding.UTF8, "application/json");
        //    var res = cl.PostAsync(URLApi, content);
        //    var client = new RestSharp.RestClient($"https://api.freecurrencyapi.com/api/latest.json?app_id={APIKey}");
        //    //var request = new RestRequest(Method.Get);
        //}
    }
}
