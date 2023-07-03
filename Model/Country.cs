using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace GeoAPI.Models
{
    public class Country
    {
        public int Id { get; set; }

        private string _countryCode;

        [JsonProperty("ccn3")]
        public string CountryCode 
        {
            get => _countryCode;
            set
            {
                _countryCode = value;
                Id = int.Parse(_countryCode);
            }
        }
        
        [JsonProperty("name")]
        public CountryName Name { get; set; }

        [JsonProperty("capital")]
        public List<string> Capital { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }
    }

    public class CountryName
    {
        [JsonProperty("common")]
        public string Common { get; set; }
    }

    public class Favorite
    {
        public int Id { get; set; }
        public string CountryJson { get; set; }

        [NotMapped]
        public Country CountryData
        {
            get => JsonConvert.DeserializeObject<Country>(CountryJson);
            set
            {
                CountryJson = JsonConvert.SerializeObject(value);
                if (value != null)
                {
                    Id = value.Id;
                }
            }
        }
    }
}
