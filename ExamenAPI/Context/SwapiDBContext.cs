using ExamenAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Context
{
    public class SwapiDBContext : DbContext

    {
         public DbSet<People> Peoples { get; set; }
         public DbSet<Planet> Planets { get; set; }
         public DbSet< Specie> Species { get; set; }
         public DbSet< Starship> Starships { get; set; }
         public DbSet< Vehicle> Vehicles { get; set; }


        public DbSet<PeopleShort> PeopleShortV { get; set; }
        public DbSet<PlanetShort> PlanetsShortV{ get; set; }
        public DbSet<SpeciesShort> SpeciesShortV{ get; set; }
        public DbSet<StarshipsShort> StarshipsShortV { get; set; }
        public DbSet<VehiclesShort> VehiclesShortsV { get; set; }




        public SwapiDBContext(DbContextOptions<SwapiDBContext>options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PeopleShort>().HasNoKey();
            modelBuilder.Entity<PlanetShort>().HasNoKey();
            modelBuilder.Entity<SpeciesShort>().HasNoKey();
            modelBuilder.Entity<StarshipsShort>().HasNoKey();
            modelBuilder.Entity<VehiclesShort>().HasNoKey();


        }
    }
}
