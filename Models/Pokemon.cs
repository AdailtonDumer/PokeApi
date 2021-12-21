namespace PokeApi.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Weight { get; set; }
        public List<PokemonAbilities> Abilities { get; set; }
        public List<PokemonTypes> Types { get; set; }
        public string DataImage { get; set; }
    }


    public class PokemonAbilities
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public string Description { get; set; }
    }

    public class PokemonTypes
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public string Description { get; set; }
    }
}
