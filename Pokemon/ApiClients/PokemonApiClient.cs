using PokeApiNet;
using System.Threading.Tasks;

namespace Pokemon.ApiClients
{
    public interface IPokemonApiClient
    {
        Task<PokeApiNet.Pokemon> GetPokemon(string name);

        Task<PokemonSpecies> GetPokemonSpecies(PokeApiNet.Pokemon pokemon);
    }

    public sealed class PokemonApiClient : IPokemonApiClient
    {
        private readonly PokeApiNet.PokeApiClient pokeClient;

        public PokemonApiClient()
        {
            pokeClient = new PokeApiNet.PokeApiClient();
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
                species = await pokeClient.GetResourceAsync(pokemon.Species).ConfigureAwait(false);
            }
            catch
            {
                species = null;
            }

            return species;
        }
    }
}
