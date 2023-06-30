using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoAPI.Models;
using GeoAPI.Services;
using System.Threading.Tasks;

namespace GeoAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly CountriesService _countriesService;
        private readonly FavoritesService _favoritesService;

        public CountriesController(CountriesService countriesService, FavoritesService favoritesService)
        {
            _countriesService = countriesService;
            _favoritesService = favoritesService;
        }

        // GET {resource}?q={query}
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

        // GET all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllCountries()
        {
            var results = await _countriesService.GetAllCountries();
            if (results == null || results.Count == 0)
            {
                return NotFound();
            }
            return Ok(results);
        }

        // POST favorites
        [HttpPost("favorites")]
        public IActionResult AddFavorite([FromBody] Country country)
        {
            var favorite = _favoritesService.AddFavorite(country);
            if (favorite == null)
            {
                return BadRequest("Failed to add favorite.");
            }
            return Ok(favorite);
        }

        // GET favorites
        [HttpGet("favorites")]
        public IActionResult GetFavorites()
        {
            var favorites = _favoritesService.GetFavorites();
            return Ok(favorites);
        }

        // DELETE favorites/{id}
        [HttpDelete("favorites/{id}")]
        public IActionResult RemoveFavorite(int id)
        {
            var removed = _favoritesService.RemoveFavorite(id);
            if (!removed)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
