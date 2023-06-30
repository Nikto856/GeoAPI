using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoAPI.Models
{
    public class Country
    {
        [JsonProperty("name")]
        public CountryName Name { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

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
            set => CountryJson = JsonConvert.SerializeObject(value);
        }
    }

}
