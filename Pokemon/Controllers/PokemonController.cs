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
                var pokemon = await _pokemonService.GetPokemon(name).ConfigureAwait(false);
                if (pokemon != null)
                {
                    return Ok(pokemon);
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
