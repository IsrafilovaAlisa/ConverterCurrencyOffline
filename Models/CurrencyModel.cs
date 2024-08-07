﻿using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace utf.Models
{
    /// <summary> модель для определения целевой валюты </summary>
    public partial class CurrencyModel
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {

        [JsonPropertyName("AUD")]
        public double AUD { get; set; }

        [JsonPropertyName("BGN")]
        public double BGN { get; set; }

        [JsonPropertyName("BRL")]
        public double BRL { get; set; }

        [JsonPropertyName("CAD")]
        public double CAD { get; set; }

        [JsonPropertyName("CHF")]
        public double CHF { get; set; }

        [JsonPropertyName("CNY")]
        public double CNY { get; set; }

        [JsonPropertyName("CZK")]
        public double CZK { get; set; }

        [JsonPropertyName("DKK")]
        public double DKK { get; set; }

        [JsonPropertyName("EUR")]
        public double EUR { get; set; }

        [JsonPropertyName("GBP")]
        public double GBP { get; set; }

        [JsonPropertyName("HKD")]
        public double HKD { get; set; }

        [JsonPropertyName("HRK")]
        public double HRK { get; set; }

        [JsonPropertyName("HUF")]
        public double HUF { get; set; }

        [JsonPropertyName("IDR")]
        public double IDR { get; set; }

        [JsonPropertyName("ILS")]
        public double ILS { get; set; }

        [JsonPropertyName("INR")]
        public double INR { get; set; }

        [JsonPropertyName("ISK")]
        public double ISK { get; set; }

        [JsonPropertyName("JPY")]
        public double JPY { get; set; }

        [JsonPropertyName("KRW")]
        public double KRW { get; set; }

        [JsonPropertyName("MXN")]
        public double MXN { get; set; }

        [JsonPropertyName("MYR")]
        public double MYR { get; set; }

        [JsonPropertyName("NOK")]
        public double NOK { get; set; }

        [JsonPropertyName("NZD")]
        public double NZD { get; set; }

        [JsonPropertyName("PHP")]
        public double PHP { get; set; }

        [JsonPropertyName("PLN")]
        public double PLN { get; set; }

        [JsonPropertyName("RON")]
        public double RON { get; set; }

        [JsonPropertyName("RUB")]
        public double RUB { get; set; }

        [JsonPropertyName("SEK")]
        public double SEK { get; set; }

        [JsonPropertyName("SGD")]
        public double SGD { get; set; }

        [JsonPropertyName("THB")]
        public double THB { get; set; }

        [JsonPropertyName("TRY")]
        public double TRY { get; set; }

        [JsonPropertyName("USD")]
        public double USD { get; set; }

        [JsonPropertyName("ZAR")]
        public double ZAR { get; set; }
    }
}
    


