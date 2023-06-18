using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoAPI.Models;
using GeoAPI.Services;
using System.Threading.Tasks;

namespace GeoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly CountriesService _countriesService;

        public CountriesController(CountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet("{resource}")]
        public async Task<IActionResult> Search(string resource, [FromQuery] string q)
        {
            var results = await _countriesService.SearchCountries(resource, q);
            if (results == null || results.Count == 0)
            {
                return NotFound();
            }
            return Ok(results);
        }

        [HttpPost("favorites")]
        public IActionResult AddFavorite([FromBody] Country country)
        {
            // Implement logic to add the country to the user's favorites list
            // Store the favorite in the chosen database

            return Ok();
        }

        [HttpGet("favorites")]
        public IActionResult GetFavorites()
        {
            // Implement logic to retrieve the user's favorites list from the database

            return Ok();
        }

        [HttpDelete("favorites/{id}")]
        public IActionResult RemoveFavorite(string id)
        {
            // Implement logic to remove the specified favorite from the user's favorites list
            // Remove the favorite from the database based on the provided id

            return Ok();
        }
    }
}
