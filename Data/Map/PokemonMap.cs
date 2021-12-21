using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokeApi.Models;

namespace PokeApi.Data.Map
{
    public class PokemonMap : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Weight).HasColumnType("numeric(7,2)");
        }
    }
}
