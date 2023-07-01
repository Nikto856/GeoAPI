using Microsoft.EntityFrameworkCore;
using GeoAPI.Models;
using Newtonsoft.Json;

namespace GeoAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Favorite> Favorites { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Country>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
