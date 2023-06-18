using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeoAPI.Models
{
    public class Country
    {
        [JsonProperty("name")]
        public CountryName Name { get; set; }

        [JsonProperty("capital")]
        public List<string> Capital { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("currencies")]
        public Dictionary<string, Currency> Currencies { get; set; }
    }

    public class CountryName
    {
        [JsonProperty("common")]
        public string Common { get; set; }
    }

    public class Currency
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
