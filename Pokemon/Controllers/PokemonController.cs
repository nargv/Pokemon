using Microsoft.AspNetCore.Mvc;
using Pokemon.Services;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var pokemon = await _pokemonService.GetPokemon(name);
                if (pokemon != null)
                {
                    return Ok(pokemon);
                }
                return NotFound();
            }
            var result = BadRequest();
            return result;
        }
    }
}
