using Pokemon.Models;
using Pokemon.Wrappers;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public interface IPokemonService
    {
        Task<PokemonModel> GetPokemon(string name);
    }

    public class PokemonService : IPokemonService
    {
        private readonly IPokeApiWrapper _pokeApiWrapper;

        public PokemonService(IPokeApiWrapper pokeApiWrapper)
        {
            _pokeApiWrapper = pokeApiWrapper;
        }

        public async Task<PokemonModel> GetPokemon(string name)
        {
            var pokemon = await _pokeApiWrapper.GetPokemon(name);

            return PokemonModel.MapPokemon(pokemon);
        }
    }
}
