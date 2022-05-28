using PokeApiNet;
using System.Threading.Tasks;

namespace Pokemon.Services
{
    public interface IPokemonService
    {
        Task<PokeApiNet.Pokemon> GetPokemon(string name);
    }

    public class PokemonService : IPokemonService
    {
        private readonly PokeApiClient pokeClient;

        public PokemonService()
        {
            pokeClient = new PokeApiClient();
        }

        public async Task<PokeApiNet.Pokemon> GetPokemon(string name)
        {
            PokeApiNet.Pokemon pokemon = null;
            try
            {
                pokemon = await pokeClient.GetResourceAsync<PokeApiNet.Pokemon>(name).ConfigureAwait(false);
            }
            catch
            {}

            return pokemon;
        }
    }
}
