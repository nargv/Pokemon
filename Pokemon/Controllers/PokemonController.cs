using Microsoft.AspNetCore.Mvc;
using PokeApiNet;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokeApiClient pokeClient;

        public PokemonController()
        {
            pokeClient = new PokeApiClient();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            if (name != null && name.Length > 2)
            {
                var pikachu = await pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(name).ConfigureAwait(false);
                if (pikachu != null)
                {
                    return Ok(pikachu);
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
