using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace utf.Models
{
    public partial class CurrencyModel
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("CAD")]
        public double Cad { get; set; }

        [JsonPropertyName("EUR")]
        public double Eur { get; set; }

        [JsonPropertyName("USD")]
        public double Usd { get; set; }
    }
}

