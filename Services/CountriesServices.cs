using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GeoAPI.Models;
using Newtonsoft.Json;

namespace GeoAPI.Services
{
    public class CountriesService
    {
        private readonly HttpClient _httpClient;

        public CountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Country>> SearchCountries(string resource, string query)
        {
            var apiUrl = $"https://restcountries.com/v3.1/{resource}/{query}";
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var countries = JsonConvert.DeserializeObject<List<Country>>(responseContent);
                return countries;
            }
            return null;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            var apiUrl = "https://restcountries.com/v3.1/all";
            var response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var countries = JsonConvert.DeserializeObject<List<Country>>(responseContent);
                return countries;
            }
            return null;
        }
    }
}
