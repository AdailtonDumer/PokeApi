using Microsoft.EntityFrameworkCore;
using PokeApi.Data.Map;
using PokeApi.Models;

namespace PokeApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonTypes> PokemonTypes { get; set; }
        public DbSet<PokemonAbilities> PokemonAbilities { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PokeDB;Data Source=localhost");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PokemonMap());
        }

    }
}
