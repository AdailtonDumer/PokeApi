using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeApi.Data;
using PokeApi.Models;

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("Pokemon")]
    public class PokemonController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var context = new DatabaseContext();
                var pokemon = context.Pokemons.ToList();
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var context = new DatabaseContext();
                var pokemon = context.Pokemons.Where(x => x.Id == id).Include(x => x.Abilities).Include(x => x.Types).FirstOrDefault();
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Add(Pokemon pokemon)
        {
            try
            {
                var context = new DatabaseContext();

                context.Pokemons.Add(pokemon);
                context.SaveChanges();

                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pokemon pokemon)
        {
            try
            {
                if(id != pokemon.Id)
                {
                    return BadRequest();
                }
                var context = new DatabaseContext();
                context.Entry(pokemon).State = EntityState.Modified;
                context.PokemonAbilities.UpdateRange(pokemon.Abilities);
                context.PokemonTypes.UpdateRange(pokemon.Types);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var context = new DatabaseContext();
                var pokemon = context.Pokemons.Where(x => x.Id == id).FirstOrDefault();
                if(pokemon == null)
                {
                    throw new Exception("Id not found on database");
                }

                context.Pokemons.Remove(pokemon);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { message = ex.Message });
            }
        }
    }
}
