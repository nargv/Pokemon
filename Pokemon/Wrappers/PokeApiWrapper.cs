using PokeApiNet;
using System.Threading.Tasks;

namespace Pokemon.Wrappers
{
    public interface IPokeApiWrapper
    {
        Task<PokeApiNet.Pokemon> GetPokemon(string name);

        Task<PokemonSpecies> GetPokemonSpecies(PokeApiNet.Pokemon pokemon);
    }

    public class PokeApiWrapper : IPokeApiWrapper
    {
        private readonly PokeApiClient pokeClient;

        public PokeApiWrapper()
        {
            pokeClient = new PokeApiClient();
        }

        public async Task<PokeApiNet.Pokemon> GetPokemon(string name)
        {
            PokeApiNet.Pokemon pokemon;
            try
            {
                pokemon = await pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(name).ConfigureAwait(false);
            }
            catch
            {
                pokemon = null;
            }

            return pokemon;
        }

        public async Task<PokemonSpecies> GetPokemonSpecies(PokeApiNet.Pokemon pokemon)
        {
            PokemonSpecies species;
            try
            {
                species = await pokeClient.GetResourceAsync(pokemon.Species);
            }
            catch
            {
                species = null;
            }

            return species;
        }
    }
}
