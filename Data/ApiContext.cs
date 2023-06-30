using Microsoft.EntityFrameworkCore;
using GeoAPI.Models;

namespace GeoAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Favorite> Favorites { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
    }
}
