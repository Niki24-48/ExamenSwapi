using ExamenAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Context
{
    public class SwapiDBContext : DbContext

    {
         public DbSet<People> People { get; set; }
         public DbSet<Planet> Planets { get; set; }
         public DbSet< Specie> Species { get; set; }
         public DbSet< Starship> Starships { get; set; }
         public DbSet< Vehicle> Vehicles { get; set; }

        public SwapiDBContext(DbContextOptions<SwapiDBContext>options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
