using System.Collections.Generic;
using System.Linq;
using GeoAPI.Models;
using GeoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GeoAPI.Services
{
    // Handling CRUD for favorites
    public class FavoritesService
    {
        private readonly DbContextOptions<ApiContext> _dbContextOptions;

        public FavoritesService(DbContextOptions<ApiContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        // POST
        public Favorite AddFavorite(Country country)
        {
            using var context = new ApiContext(_dbContextOptions);
            var favorite = new Favorite { Country = country };

            context.Favorites.Add(favorite);
            context.SaveChanges();

            return favorite;
        }

        // GET
        public List<Favorite> GetFavorites()
        {
            using var context = new ApiContext(_dbContextOptions);
            return context.Favorites.Include(f => f.Country).ToList();
        }

        // DELETE
        public bool RemoveFavorite(int id)
        {
            using var context = new ApiContext(_dbContextOptions);
            var favorite = context.Favorites.FirstOrDefault(f => f.Id == id);

            if (favorite != null)
            {
                context.Favorites.Remove(favorite);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
